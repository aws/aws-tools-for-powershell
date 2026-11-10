/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.CompilerServices;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Redacts on the host a sensitive value that a cmdlet returns on its own (the default -Select), which
    /// otherwise has no redacting format view. The value is tagged for the AWS.Tools.SensitiveData views;
    /// values and .NET types are unchanged.
    /// </summary>
    public static class SensitiveOutput
    {
        // Makes PowerShell 7 apply the string views.
        private const string NotePropertyName = "AWSSensitive";

        // PowerShell 7 writes a tagged string without its view: the adapter's property check stops at the Chars
        // indexer and reports no properties. A note property passes that check. Windows PowerShell 5.1 applies the
        // view without one, and its ConvertTo-Json would write a string with a note property as {"value":...}.
        private static readonly bool NeedsNoteProperty = typeof(PSObject).Assembly.GetName().Version.Major >= 6;

        private static object RedactOnHost(string value)
        {
            // With redaction already off, return the plain string: a tagged one would still change Export-Csv and
            // ConvertTo-Csv output (an AWSSensitive column on PowerShell 7, the #TYPE line on 5.1).
            if (value == null || ShowSensitiveData())
                return value;

            var wrapped = Tag(value);
            if (NeedsNoteProperty)
            {
                // Where the views don't apply (a runspace without the module, ConvertTo-Csv), the
                // object shows only this property, so it reads as redacted.
                wrapped.Properties.Add(new PSNoteProperty(NotePropertyName, BaseCmdlet.SensitiveDataRedactionMessage));
                wrapped.Members.Add(new PSMemberSet("PSStandardMembers", new PSMemberInfo[]
                {
                    new PSPropertySet("DefaultDisplayPropertySet", new[] { NotePropertyName })
                }));
            }
            return wrapped;
        }

        /// <summary>
        /// Tags the string for the AWS.Tools.SensitiveData views when redaction is on and, when it is redacted,
        /// tells the user how to see it.
        /// </summary>
        public static object RedactOnHost(string value, PSCmdlet cmdlet, string selectProperty)
        {
            var output = RedactOnHost(value);
            if (output is PSObject)
                WriteRedactionNote(cmdlet, selectProperty);
            return output;
        }

        /// <summary>
        /// Type name inserted on each element of a sensitive non-string output. The generated
        /// AWS.Tools.SensitiveData#&lt;type&gt; views and the generic views in AWS.Tools.Common redact it.
        /// </summary>
        public const string TypeName = "AWS.Tools.SensitiveData";

        // Tags a sensitive non-string value, or each element of a collection, for the redacting views.
        private static object TagForHost(object value)
        {
            if (value == null)
                return null;

            // ProcessOutput writes collection elements one by one, so the tag must be on each element.
            var enumerator = LanguagePrimitives.GetEnumerator(value);
            if (enumerator == null)
                return Tag(value);

            var tagged = new List<object>();
            while (enumerator.MoveNext())
                tagged.Add(Tag(enumerator.Current));
            return tagged;
        }

        /// <summary>
        /// When redaction is on, tags the value, or each element of a collection, for the redacting views and,
        /// when there is output, tells the user how to see it.
        /// </summary>
        public static object TagForHost(object value, PSCmdlet cmdlet, string selectProperty)
        {
            // With redaction already off, return the plain value, as RedactOnHost does for strings.
            if (value == null || ShowSensitiveData())
                return value;

            var output = TagForHost(value);
            if (!IsEmpty(output))
                WriteRedactionNote(cmdlet, selectProperty);
            return output;
        }

        // A tagged dictionary is wrapped, not enumerated, so the check looks through the wrapper.
        private static bool IsEmpty(object output) =>
            PSObject.AsPSObject(output).BaseObject is ICollection collection && collection.Count == 0;

        // Names of the cmdlets that have written the note, per session, so a script calling one in a loop logs it once.
        private static readonly ConditionalWeakTable<Runspace, HashSet<string>> NotedCommands =
            new ConditionalWeakTable<Runspace, HashSet<string>>();

        private static void WriteRedactionNote(PSCmdlet cmdlet, string selectProperty)
        {
            var commandName = cmdlet.MyInvocation.MyCommand.Name;
            if (!NotedCommands.GetOrCreateValue(Runspace.DefaultRunspace).Add(commandName) || NoteWouldStopOrPrompt(cmdlet))
                return;

            // Written as Write-Host writes, so it shows by default and -InformationAction Ignore silences it.
            var note = new HostInformationMessage
            {
                Message = $"Note: {commandName} output is redacted on display.{Environment.NewLine}" +
                          $"      To see it, use -Select {selectProperty} or{Environment.NewLine}" +
                          "      Set-AWSSensitiveDataConfiguration -ShowSensitiveData $true."
            };
            cmdlet.WriteInformation(note, new[] { "PSHOST" });
        }

        // Under Stop or Inquire, WriteInformation throws or prompts, and the cmdlet would lose its output for a hint.
        private static bool NoteWouldStopOrPrompt(PSCmdlet cmdlet)
        {
            if (!cmdlet.MyInvocation.BoundParameters.TryGetValue("InformationAction", out var preference))
                preference = cmdlet.SessionState.PSVariable.GetValue("InformationPreference");
            return LanguagePrimitives.TryConvertTo(preference, out ActionPreference action) &&
                   (action == ActionPreference.Stop || action == ActionPreference.Inquire);
        }

        private static bool ShowSensitiveData()
        {
            using (var ps = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                var value = ps.AddCommand("Get-Variable")
                    .AddParameter("Name", SessionKeys.AWSShowSensitiveData)
                    .AddParameter("ValueOnly")
                    .AddParameter("ErrorAction", ActionPreference.Ignore)
                    .Invoke();
                return value.Count == 1 && true.Equals(value[0]?.BaseObject);
            }
        }

        private static PSObject Tag(object item)
        {
            if (item == null)
                return null;

            var wrapped = PSObject.AsPSObject(item);
            wrapped.TypeNames.Insert(0, TypeName + "#" + item.GetType().FullName);
            wrapped.TypeNames.Insert(1, TypeName);
            return wrapped;
        }
    }
}
