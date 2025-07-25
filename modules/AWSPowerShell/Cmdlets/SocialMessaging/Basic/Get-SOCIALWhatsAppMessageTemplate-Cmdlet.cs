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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Retrieves a specific WhatsApp message template.
    /// </summary>
    [Cmdlet("Get", "SOCIALWhatsAppMessageTemplate")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS End User Messaging Social GetWhatsAppMessageTemplate API operation.", Operation = new[] {"GetWhatsAppMessageTemplate"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSOCIALWhatsAppMessageTemplateCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account associated with this template.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter MetaTemplateId
        /// <summary>
        /// <para>
        /// <para>The numeric ID of the template assigned by Meta.</para>
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
        public System.String MetaTemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Template'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Template";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse, GetSOCIALWhatsAppMessageTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetaTemplateId = this.MetaTemplateId;
            #if MODULAR
            if (this.MetaTemplateId == null && ParameterWasBound(nameof(this.MetaTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.MetaTemplateId != null)
            {
                request.MetaTemplateId = cmdletContext.MetaTemplateId;
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
        
        private Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "GetWhatsAppMessageTemplate");
            try
            {
                return client.GetWhatsAppMessageTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String MetaTemplateId { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.GetWhatsAppMessageTemplateResponse, GetSOCIALWhatsAppMessageTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Template;
        }
        
    }
}
