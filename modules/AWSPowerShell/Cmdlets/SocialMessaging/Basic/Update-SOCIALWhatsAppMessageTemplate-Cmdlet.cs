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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Updates an existing WhatsApp message template.
    /// </summary>
    [Cmdlet("Update", "SOCIALWhatsAppMessageTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS End User Messaging Social UpdateWhatsAppMessageTemplate API operation.", Operation = new[] {"UpdateWhatsAppMessageTemplate"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSOCIALWhatsAppMessageTemplateCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CtaUrlLinkTrackingOptedOut
        /// <summary>
        /// <para>
        /// <para>When true, disables click tracking for call-to-action URL buttons in the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CtaUrlLinkTrackingOptedOut { get; set; }
        #endregion
        
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
        
        #region Parameter ParameterFormat
        /// <summary>
        /// <para>
        /// <para>The format specification for parameters in the template, this can be either 'named'
        /// or 'positional'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterFormat { get; set; }
        #endregion
        
        #region Parameter TemplateCategory
        /// <summary>
        /// <para>
        /// <para>The new category for the template (for example, UTILITY or MARKETING).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateCategory { get; set; }
        #endregion
        
        #region Parameter TemplateComponent
        /// <summary>
        /// <para>
        /// <para>The updated components of the template as a JSON blob (maximum 3000 characters).</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateComponents")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] TemplateComponent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SOCIALWhatsAppMessageTemplate (UpdateWhatsAppMessageTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse, UpdateSOCIALWhatsAppMessageTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CtaUrlLinkTrackingOptedOut = this.CtaUrlLinkTrackingOptedOut;
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
            context.ParameterFormat = this.ParameterFormat;
            context.TemplateCategory = this.TemplateCategory;
            context.TemplateComponent = this.TemplateComponent;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _TemplateComponentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateRequest();
                
                if (cmdletContext.CtaUrlLinkTrackingOptedOut != null)
                {
                    request.CtaUrlLinkTrackingOptedOut = cmdletContext.CtaUrlLinkTrackingOptedOut.Value;
                }
                if (cmdletContext.Id != null)
                {
                    request.Id = cmdletContext.Id;
                }
                if (cmdletContext.MetaTemplateId != null)
                {
                    request.MetaTemplateId = cmdletContext.MetaTemplateId;
                }
                if (cmdletContext.ParameterFormat != null)
                {
                    request.ParameterFormat = cmdletContext.ParameterFormat;
                }
                if (cmdletContext.TemplateCategory != null)
                {
                    request.TemplateCategory = cmdletContext.TemplateCategory;
                }
                if (cmdletContext.TemplateComponent != null)
                {
                    _TemplateComponentStream = new System.IO.MemoryStream(cmdletContext.TemplateComponent);
                    request.TemplateComponents = _TemplateComponentStream;
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
            finally
            {
                if( _TemplateComponentStream != null)
                {
                    _TemplateComponentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "UpdateWhatsAppMessageTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateWhatsAppMessageTemplate(request);
                #elif CORECLR
                return client.UpdateWhatsAppMessageTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CtaUrlLinkTrackingOptedOut { get; set; }
            public System.String Id { get; set; }
            public System.String MetaTemplateId { get; set; }
            public System.String ParameterFormat { get; set; }
            public System.String TemplateCategory { get; set; }
            public byte[] TemplateComponent { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.UpdateWhatsAppMessageTemplateResponse, UpdateSOCIALWhatsAppMessageTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
