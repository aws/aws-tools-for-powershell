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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Updates an existing configuration set.
    /// 
    ///  
    /// <para>
    /// This operation performs a partial update. Only the attributes that you include in
    /// the request are updated; any omitted attribute is left unchanged.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SES2ConfigurationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) UpdateConfigurationSet API operation.", Operation = new[] {"UpdateConfigurationSet"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSES2ConfigurationSetCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter MessageSecurityOptions_SigningScheme_DefaultScheme
        /// <summary>
        /// <para>
        /// <para>Use the default signing behavior. When you select this option, Amazon SES API v2 doesn't
        /// add an S/MIME signature to messages sent with the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SimpleEmailV2.Model.DefaultSigningScheme MessageSecurityOptions_SigningScheme_DefaultScheme { get; set; }
        #endregion
        
        #region Parameter MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat
        /// <summary>
        /// <para>
        /// <para>The format of the S/MIME signature that Amazon SES API v2 applies to messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SignatureFormat")]
        public Amazon.SimpleEmailV2.SignatureFormat MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SES2ConfigurationSet (UpdateConfigurationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse, UpdateSES2ConfigurationSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageSecurityOptions_SigningScheme_DefaultScheme = this.MessageSecurityOptions_SigningScheme_DefaultScheme;
            context.MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat = this.MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat;
            
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
            var request = new Amazon.SimpleEmailV2.Model.UpdateConfigurationSetRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate MessageSecurityOptions
            var requestMessageSecurityOptionsIsNull = true;
            request.MessageSecurityOptions = new Amazon.SimpleEmailV2.Model.MessageSecurityOptions();
            Amazon.SimpleEmailV2.Model.SigningScheme requestMessageSecurityOptions_messageSecurityOptions_SigningScheme = null;
            
             // populate SigningScheme
            var requestMessageSecurityOptions_messageSecurityOptions_SigningSchemeIsNull = true;
            requestMessageSecurityOptions_messageSecurityOptions_SigningScheme = new Amazon.SimpleEmailV2.Model.SigningScheme();
            Amazon.SimpleEmailV2.Model.DefaultSigningScheme requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_DefaultScheme = null;
            if (cmdletContext.MessageSecurityOptions_SigningScheme_DefaultScheme != null)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_DefaultScheme = cmdletContext.MessageSecurityOptions_SigningScheme_DefaultScheme;
            }
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_DefaultScheme != null)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme.DefaultScheme = requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_DefaultScheme;
                requestMessageSecurityOptions_messageSecurityOptions_SigningSchemeIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.SmimeSigningScheme requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme = null;
            
             // populate SmimeScheme
            var requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeSchemeIsNull = true;
            requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme = new Amazon.SimpleEmailV2.Model.SmimeSigningScheme();
            Amazon.SimpleEmailV2.SignatureFormat requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme_messageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat = null;
            if (cmdletContext.MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat != null)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme_messageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat = cmdletContext.MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat;
            }
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme_messageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat != null)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme.SignatureFormat = requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme_messageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat;
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeSchemeIsNull = false;
            }
             // determine if requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme should be set to null
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeSchemeIsNull)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme = null;
            }
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme != null)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme.SmimeScheme = requestMessageSecurityOptions_messageSecurityOptions_SigningScheme_messageSecurityOptions_SigningScheme_SmimeScheme;
                requestMessageSecurityOptions_messageSecurityOptions_SigningSchemeIsNull = false;
            }
             // determine if requestMessageSecurityOptions_messageSecurityOptions_SigningScheme should be set to null
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningSchemeIsNull)
            {
                requestMessageSecurityOptions_messageSecurityOptions_SigningScheme = null;
            }
            if (requestMessageSecurityOptions_messageSecurityOptions_SigningScheme != null)
            {
                request.MessageSecurityOptions.SigningScheme = requestMessageSecurityOptions_messageSecurityOptions_SigningScheme;
                requestMessageSecurityOptionsIsNull = false;
            }
             // determine if request.MessageSecurityOptions should be set to null
            if (requestMessageSecurityOptionsIsNull)
            {
                request.MessageSecurityOptions = null;
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
        
        private Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.UpdateConfigurationSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "UpdateConfigurationSet");
            try
            {
                return client.UpdateConfigurationSetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Amazon.SimpleEmailV2.Model.DefaultSigningScheme MessageSecurityOptions_SigningScheme_DefaultScheme { get; set; }
            public Amazon.SimpleEmailV2.SignatureFormat MessageSecurityOptions_SigningScheme_SmimeScheme_SignatureFormat { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.UpdateConfigurationSetResponse, UpdateSES2ConfigurationSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
