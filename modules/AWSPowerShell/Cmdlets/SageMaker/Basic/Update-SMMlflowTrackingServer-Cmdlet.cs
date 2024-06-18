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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates properties of an existing MLflow Tracking Server.
    /// </summary>
    [Cmdlet("Update", "SMMlflowTrackingServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateMlflowTrackingServer API operation.", Operation = new[] {"UpdateMlflowTrackingServer"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMMlflowTrackingServerCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArtifactStoreUri
        /// <summary>
        /// <para>
        /// <para>The new S3 URI for the general purpose bucket to use as the artifact store for the
        /// MLflow Tracking Server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactStoreUri { get; set; }
        #endregion
        
        #region Parameter AutomaticModelRegistration
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable automatic registration of new MLflow models to the SageMaker
        /// Model Registry. To enable automatic model registration, set this value to <c>True</c>.
        /// To disable automatic model registration, set this value to <c>False</c>. If not specified,
        /// <c>AutomaticModelRegistration</c> defaults to <c>False</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutomaticModelRegistration { get; set; }
        #endregion
        
        #region Parameter TrackingServerName
        /// <summary>
        /// <para>
        /// <para>The name of the MLflow Tracking Server to update.</para>
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
        public System.String TrackingServerName { get; set; }
        #endregion
        
        #region Parameter TrackingServerSize
        /// <summary>
        /// <para>
        /// <para>The new size for the MLflow Tracking Server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TrackingServerSize")]
        public Amazon.SageMaker.TrackingServerSize TrackingServerSize { get; set; }
        #endregion
        
        #region Parameter WeeklyMaintenanceWindowStart
        /// <summary>
        /// <para>
        /// <para>The new weekly maintenance window start day and time to update. The maintenance window
        /// day and time should be in Coordinated Universal Time (UTC) 24-hour standard time.
        /// For example: TUE:03:30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WeeklyMaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrackingServerArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrackingServerArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrackingServerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrackingServerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrackingServerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackingServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMMlflowTrackingServer (UpdateMlflowTrackingServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse, UpdateSMMlflowTrackingServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrackingServerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ArtifactStoreUri = this.ArtifactStoreUri;
            context.AutomaticModelRegistration = this.AutomaticModelRegistration;
            context.TrackingServerName = this.TrackingServerName;
            #if MODULAR
            if (this.TrackingServerName == null && ParameterWasBound(nameof(this.TrackingServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackingServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrackingServerSize = this.TrackingServerSize;
            context.WeeklyMaintenanceWindowStart = this.WeeklyMaintenanceWindowStart;
            
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
            var request = new Amazon.SageMaker.Model.UpdateMlflowTrackingServerRequest();
            
            if (cmdletContext.ArtifactStoreUri != null)
            {
                request.ArtifactStoreUri = cmdletContext.ArtifactStoreUri;
            }
            if (cmdletContext.AutomaticModelRegistration != null)
            {
                request.AutomaticModelRegistration = cmdletContext.AutomaticModelRegistration.Value;
            }
            if (cmdletContext.TrackingServerName != null)
            {
                request.TrackingServerName = cmdletContext.TrackingServerName;
            }
            if (cmdletContext.TrackingServerSize != null)
            {
                request.TrackingServerSize = cmdletContext.TrackingServerSize;
            }
            if (cmdletContext.WeeklyMaintenanceWindowStart != null)
            {
                request.WeeklyMaintenanceWindowStart = cmdletContext.WeeklyMaintenanceWindowStart;
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
        
        private Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateMlflowTrackingServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateMlflowTrackingServer");
            try
            {
                #if DESKTOP
                return client.UpdateMlflowTrackingServer(request);
                #elif CORECLR
                return client.UpdateMlflowTrackingServerAsync(request).GetAwaiter().GetResult();
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
            public System.String ArtifactStoreUri { get; set; }
            public System.Boolean? AutomaticModelRegistration { get; set; }
            public System.String TrackingServerName { get; set; }
            public Amazon.SageMaker.TrackingServerSize TrackingServerSize { get; set; }
            public System.String WeeklyMaintenanceWindowStart { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateMlflowTrackingServerResponse, UpdateSMMlflowTrackingServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrackingServerArn;
        }
        
    }
}
