/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Creates and defines the criteria and other settings for a custom data identifier.
    /// </summary>
    [Cmdlet("New", "MAC2CustomDataIdentifier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Macie 2 CreateCustomDataIdentifier API operation.", Operation = new[] {"CreateCustomDataIdentifier"}, SelectReturnType = typeof(Amazon.Macie2.Model.CreateCustomDataIdentifierResponse))]
    [AWSCmdletOutput("System.String or Amazon.Macie2.Model.CreateCustomDataIdentifierResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Macie2.Model.CreateCustomDataIdentifierResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMAC2CustomDataIdentifierCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description of the custom data identifier. The description can contain as
        /// many as 512 characters.</para><para>We strongly recommend that you avoid including any sensitive data in the description
        /// of a custom data identifier. Other users of your account might be able to see this
        /// description, depending on the actions that they're allowed to perform in Amazon Macie.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IgnoreWord
        /// <summary>
        /// <para>
        /// <para>An array that lists specific character sequences (<i>ignore words</i>) to exclude
        /// from the results. If the text matched by the regular expression contains any string
        /// in this array, Amazon Macie ignores it. The array can contain as many as 10 ignore
        /// words. Each ignore word can contain 4-90 UTF-8 characters. Ignore words are case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IgnoreWords")]
        public System.String[] IgnoreWord { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para>An array that lists specific character sequences (<i>keywords</i>), one of which must
        /// be within proximity (maximumMatchDistance) of the regular expression to match. The
        /// array can contain as many as 50 keywords. Each keyword can contain 3-90 UTF-8 characters.
        /// Keywords aren't case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Keywords")]
        public System.String[] Keyword { get; set; }
        #endregion
        
        #region Parameter MaximumMatchDistance
        /// <summary>
        /// <para>
        /// <para>The maximum number of characters that can exist between text that matches the regular
        /// expression and the character sequences specified by the keywords array. Amazon Macie
        /// includes or excludes a result based on the proximity of a keyword to text that matches
        /// the regular expression. The distance can be 1-300 characters. The default value is
        /// 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaximumMatchDistance { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A custom name for the custom data identifier. The name can contain as many as 128
        /// characters.</para><para>We strongly recommend that you avoid including any sensitive data in the name of a
        /// custom data identifier. Other users of your account might be able to see this name,
        /// depending on the actions that they're allowed to perform in Amazon Macie.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Regex
        /// <summary>
        /// <para>
        /// <para>The regular expression (<i>regex</i>) that defines the pattern to match. The expression
        /// can contain as many as 512 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Regex { get; set; }
        #endregion
        
        #region Parameter SeverityLevel
        /// <summary>
        /// <para>
        /// <para>The severity to assign to findings that the custom data identifier produces, based
        /// on the number of occurrences of text that matches the custom data identifier's detection
        /// criteria. You can specify as many as three SeverityLevel objects in this array, one
        /// for each severity: LOW, MEDIUM, or HIGH. If you specify more than one, the occurrences
        /// thresholds must be in ascending order by severity, moving from LOW to HIGH. For example,
        /// 1 for LOW, 50 for MEDIUM, and 100 for HIGH. If an S3 object contains fewer occurrences
        /// than the lowest specified threshold, Amazon Macie doesn't create a finding.</para><para>If you don't specify any values for this array, Macie creates findings for S3 objects
        /// that contain at least one occurrence of text that matches the detection criteria,
        /// and Macie assigns the MEDIUM severity to those findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeverityLevels")]
        public Amazon.Macie2.Model.SeverityLevel[] SeverityLevel { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs that specifies the tags to associate with the custom data
        /// identifier.</para><para>A custom data identifier can have a maximum of 50 tags. Each tag consists of a tag
        /// key and an associated tag value. The maximum length of a tag key is 128 characters.
        /// The maximum length of a tag value is 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomDataIdentifierId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.CreateCustomDataIdentifierResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.CreateCustomDataIdentifierResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomDataIdentifierId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MAC2CustomDataIdentifier (CreateCustomDataIdentifier)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.CreateCustomDataIdentifierResponse, NewMAC2CustomDataIdentifierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.IgnoreWord != null)
            {
                context.IgnoreWord = new List<System.String>(this.IgnoreWord);
            }
            if (this.Keyword != null)
            {
                context.Keyword = new List<System.String>(this.Keyword);
            }
            context.MaximumMatchDistance = this.MaximumMatchDistance;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Regex = this.Regex;
            #if MODULAR
            if (this.Regex == null && ParameterWasBound(nameof(this.Regex)))
            {
                WriteWarning("You are passing $null as a value for parameter Regex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SeverityLevel != null)
            {
                context.SeverityLevel = new List<Amazon.Macie2.Model.SeverityLevel>(this.SeverityLevel);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Macie2.Model.CreateCustomDataIdentifierRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IgnoreWord != null)
            {
                request.IgnoreWords = cmdletContext.IgnoreWord;
            }
            if (cmdletContext.Keyword != null)
            {
                request.Keywords = cmdletContext.Keyword;
            }
            if (cmdletContext.MaximumMatchDistance != null)
            {
                request.MaximumMatchDistance = cmdletContext.MaximumMatchDistance.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Regex != null)
            {
                request.Regex = cmdletContext.Regex;
            }
            if (cmdletContext.SeverityLevel != null)
            {
                request.SeverityLevels = cmdletContext.SeverityLevel;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        #region AWS Service Operation Call
        
        private Amazon.Macie2.Model.CreateCustomDataIdentifierResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.CreateCustomDataIdentifierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "CreateCustomDataIdentifier");
            try
            {
                #if DESKTOP
                return client.CreateCustomDataIdentifier(request);
                #elif CORECLR
                return client.CreateCustomDataIdentifierAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> IgnoreWord { get; set; }
            public List<System.String> Keyword { get; set; }
            public System.Int32? MaximumMatchDistance { get; set; }
            public System.String Name { get; set; }
            public System.String Regex { get; set; }
            public List<Amazon.Macie2.Model.SeverityLevel> SeverityLevel { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Macie2.Model.CreateCustomDataIdentifierResponse, NewMAC2CustomDataIdentifierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomDataIdentifierId;
        }
        
    }
}
