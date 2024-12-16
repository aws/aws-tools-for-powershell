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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Changes the status of a specific version of a message template to <i>active</i>.
    /// </summary>
    [Cmdlet("Update", "PINTemplateActiveVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateTemplateActiveVersion API operation.", Operation = new[] {"UpdateTemplateActiveVersion"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINTemplateActiveVersionCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the message template. A template name must start with an alphanumeric
        /// character and can contain a maximum of 128 characters. The characters can be alphanumeric
        /// characters, underscores (_), or hyphens (-). Template names are case sensitive.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter TemplateType
        /// <summary>
        /// <para>
        /// <para>The type of channel that the message template is designed for. Valid values are: EMAIL,
        /// PUSH, SMS, and VOICE.</para>
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
        public System.String TemplateType { get; set; }
        #endregion
        
        #region Parameter TemplateActiveVersionRequest_Version
        /// <summary>
        /// <para>
        /// <para>The version of the message template to use as the active version of the template.
        /// Valid values are: latest, for the most recent version of the template; or, the unique
        /// identifier for any existing version of the template. If you specify an identifier,
        /// the value must match the identifier for an existing template version. To retrieve
        /// a list of versions and version identifiers for a template, use the <link linkend="templates-template-name-template-type-versions">Template
        /// Versions</link> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateActiveVersionRequest_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINTemplateActiveVersion (UpdateTemplateActiveVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse, UpdatePINTemplateActiveVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TemplateActiveVersionRequest_Version = this.TemplateActiveVersionRequest_Version;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateType = this.TemplateType;
            #if MODULAR
            if (this.TemplateType == null && ParameterWasBound(nameof(this.TemplateType)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.UpdateTemplateActiveVersionRequest();
            
            
             // populate TemplateActiveVersionRequest
            var requestTemplateActiveVersionRequestIsNull = true;
            request.TemplateActiveVersionRequest = new Amazon.Pinpoint.Model.TemplateActiveVersionRequest();
            System.String requestTemplateActiveVersionRequest_templateActiveVersionRequest_Version = null;
            if (cmdletContext.TemplateActiveVersionRequest_Version != null)
            {
                requestTemplateActiveVersionRequest_templateActiveVersionRequest_Version = cmdletContext.TemplateActiveVersionRequest_Version;
            }
            if (requestTemplateActiveVersionRequest_templateActiveVersionRequest_Version != null)
            {
                request.TemplateActiveVersionRequest.Version = requestTemplateActiveVersionRequest_templateActiveVersionRequest_Version;
                requestTemplateActiveVersionRequestIsNull = false;
            }
             // determine if request.TemplateActiveVersionRequest should be set to null
            if (requestTemplateActiveVersionRequestIsNull)
            {
                request.TemplateActiveVersionRequest = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            if (cmdletContext.TemplateType != null)
            {
                request.TemplateType = cmdletContext.TemplateType;
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
        
        private Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateTemplateActiveVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateTemplateActiveVersion");
            try
            {
                #if DESKTOP
                return client.UpdateTemplateActiveVersion(request);
                #elif CORECLR
                return client.UpdateTemplateActiveVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String TemplateActiveVersionRequest_Version { get; set; }
            public System.String TemplateName { get; set; }
            public System.String TemplateType { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateTemplateActiveVersionResponse, UpdatePINTemplateActiveVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
