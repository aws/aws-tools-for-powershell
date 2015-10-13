/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Translates a textual identifier into a user-readable text in a specified locale.
    /// </summary>
    [Cmdlet("Get", "INSLocalizedText")]
    [OutputType("Amazon.Inspector.Model.LocalizeTextResponse")]
    [AWSCmdlet("Invokes the LocalizeText operation against Amazon Inspector.", Operation = new[] {"LocalizeText"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.LocalizeTextResponse",
        "This cmdlet returns a Amazon.Inspector.Model.LocalizeTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetINSLocalizedTextCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The locale that you want to translate a textual identifier into.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Locale { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of textual identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LocalizedTexts")]
        public Amazon.Inspector.Model.LocalizedText[] LocalizedText { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Locale = this.Locale;
            if (this.LocalizedText != null)
            {
                context.LocalizedTexts = new List<Amazon.Inspector.Model.LocalizedText>(this.LocalizedText);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Inspector.Model.LocalizeTextRequest();
            
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.LocalizedTexts != null)
            {
                request.LocalizedTexts = cmdletContext.LocalizedTexts;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.LocalizeText(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Locale { get; set; }
            public List<Amazon.Inspector.Model.LocalizedText> LocalizedTexts { get; set; }
        }
        
    }
}
