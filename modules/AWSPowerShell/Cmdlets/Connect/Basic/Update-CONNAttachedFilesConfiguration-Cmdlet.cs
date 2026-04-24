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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the attached files configuration for the specified Amazon Connect instance
    /// and attachment scope.
    /// 
    ///  
    /// <para>
    /// If no instance-specific configuration exists, this operation creates one. Partial
    /// updates are supported—only specified fields are updated, while unspecified fields
    /// retain their current values.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNAttachedFilesConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateAttachedFilesConfiguration API operation.", Operation = new[] {"UpdateAttachedFilesConfiguration"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse",
        "This cmdlet returns an Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateCONNAttachedFilesConfigurationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExtensionConfiguration_AllowedExtension
        /// <summary>
        /// <para>
        /// <para>The list of allowed file extensions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtensionConfiguration_AllowedExtensions")]
        public Amazon.Connect.Model.AllowedExtension[] ExtensionConfiguration_AllowedExtension { get; set; }
        #endregion
        
        #region Parameter AttachmentScope
        /// <summary>
        /// <para>
        /// <para>The scope of the attachment. Valid values are <c>EMAIL</c>, <c>CHAT</c>, <c>CASE</c>,
        /// and <c>TASK</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.AttachmentScope")]
        public Amazon.Connect.AttachmentScope AttachmentScope { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MaximumSizeLimitInByte
        /// <summary>
        /// <para>
        /// <para>The maximum size limit for attached files in bytes. The minimum value is 1 and the
        /// maximum value is 104857600 (100 MB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumSizeLimitInBytes")]
        public System.Int64? MaximumSizeLimitInByte { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNAttachedFilesConfiguration (UpdateAttachedFilesConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse, UpdateCONNAttachedFilesConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttachmentScope = this.AttachmentScope;
            #if MODULAR
            if (this.AttachmentScope == null && ParameterWasBound(nameof(this.AttachmentScope)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentScope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExtensionConfiguration_AllowedExtension != null)
            {
                context.ExtensionConfiguration_AllowedExtension = new List<Amazon.Connect.Model.AllowedExtension>(this.ExtensionConfiguration_AllowedExtension);
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumSizeLimitInByte = this.MaximumSizeLimitInByte;
            
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
            var request = new Amazon.Connect.Model.UpdateAttachedFilesConfigurationRequest();
            
            if (cmdletContext.AttachmentScope != null)
            {
                request.AttachmentScope = cmdletContext.AttachmentScope;
            }
            
             // populate ExtensionConfiguration
            var requestExtensionConfigurationIsNull = true;
            request.ExtensionConfiguration = new Amazon.Connect.Model.ExtensionConfiguration();
            List<Amazon.Connect.Model.AllowedExtension> requestExtensionConfiguration_extensionConfiguration_AllowedExtension = null;
            if (cmdletContext.ExtensionConfiguration_AllowedExtension != null)
            {
                requestExtensionConfiguration_extensionConfiguration_AllowedExtension = cmdletContext.ExtensionConfiguration_AllowedExtension;
            }
            if (requestExtensionConfiguration_extensionConfiguration_AllowedExtension != null)
            {
                request.ExtensionConfiguration.AllowedExtensions = requestExtensionConfiguration_extensionConfiguration_AllowedExtension;
                requestExtensionConfigurationIsNull = false;
            }
             // determine if request.ExtensionConfiguration should be set to null
            if (requestExtensionConfigurationIsNull)
            {
                request.ExtensionConfiguration = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaximumSizeLimitInByte != null)
            {
                request.MaximumSizeLimitInBytes = cmdletContext.MaximumSizeLimitInByte.Value;
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
        
        private Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateAttachedFilesConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateAttachedFilesConfiguration");
            try
            {
                return client.UpdateAttachedFilesConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Connect.AttachmentScope AttachmentScope { get; set; }
            public List<Amazon.Connect.Model.AllowedExtension> ExtensionConfiguration_AllowedExtension { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int64? MaximumSizeLimitInByte { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateAttachedFilesConfigurationResponse, UpdateCONNAttachedFilesConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
