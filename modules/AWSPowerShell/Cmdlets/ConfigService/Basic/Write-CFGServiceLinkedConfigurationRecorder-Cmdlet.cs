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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a service-linked configuration recorder that is linked to a specific Amazon
    /// Web Services service based on the <c>ServicePrincipal</c> you specify.
    /// 
    ///  
    /// <para>
    /// The configuration recorder's <c>name</c>, <c>recordingGroup</c>, <c>recordingMode</c>,
    /// and <c>recordingScope</c> is set by the service that is linked to the configuration
    /// recorder.
    /// </para><para>
    /// For more information and a list of supported services/service principals, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/stop-start-recorder.html"><b>Working with the Configuration Recorder</b></a> in the <i>Config Developer Guide</i>.
    /// </para><para>
    /// This API creates a service-linked role <c>AWSServiceRoleForConfig</c> in your account.
    /// The service-linked role is created only when the role does not exist in your account.
    /// </para><note><para><b>The recording scope determines if you receive configuration items</b></para><para>
    /// The recording scope is set by the service that is linked to the configuration recorder
    /// and determines whether you receive configuration items (CIs) in the delivery channel.
    /// If the recording scope is internal, you will not receive CIs in the delivery channel.
    /// </para><para><b>Tags are added at creation and cannot be updated with this operation</b></para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGServiceLinkedConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse")]
    [AWSCmdlet("Calls the AWS Config PutServiceLinkedConfigurationRecorder API operation.", Operation = new[] {"PutServiceLinkedConfigurationRecorder"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse object containing multiple properties."
    )]
    public partial class WriteCFGServiceLinkedConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServicePrincipal
        /// <summary>
        /// <para>
        /// <para>The service principal of the Amazon Web Services service for the service-linked configuration
        /// recorder that you want to create.</para>
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
        public System.String ServicePrincipal { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for a service-linked configuration recorder. Each tag consists of a key and
        /// an optional value, both of which you define.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServicePrincipal), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGServiceLinkedConfigurationRecorder (PutServiceLinkedConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse, WriteCFGServiceLinkedConfigurationRecorderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ServicePrincipal = this.ServicePrincipal;
            #if MODULAR
            if (this.ServicePrincipal == null && ParameterWasBound(nameof(this.ServicePrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter ServicePrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderRequest();
            
            if (cmdletContext.ServicePrincipal != null)
            {
                request.ServicePrincipal = cmdletContext.ServicePrincipal;
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
        
        private Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutServiceLinkedConfigurationRecorder");
            try
            {
                return client.PutServiceLinkedConfigurationRecorderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ServicePrincipal { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutServiceLinkedConfigurationRecorderResponse, WriteCFGServiceLinkedConfigurationRecorderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
