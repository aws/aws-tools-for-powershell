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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an MLflow Tracking Server using a general purpose Amazon S3 bucket as the
    /// artifact store. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/mlflow-create-tracking-server.html">Create
    /// an MLflow Tracking Server</a>.
    /// </summary>
    [Cmdlet("New", "SMMlflowTrackingServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateMlflowTrackingServer API operation.", Operation = new[] {"CreateMlflowTrackingServer"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMMlflowTrackingServerCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArtifactStoreUri
        /// <summary>
        /// <para>
        /// <para>The S3 URI for a general purpose bucket to use as the MLflow Tracking Server artifact
        /// store.</para>
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
        public System.String ArtifactStoreUri { get; set; }
        #endregion
        
        #region Parameter AutomaticModelRegistration
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable automatic registration of new MLflow models to the SageMaker
        /// Model Registry. To enable automatic model registration, set this value to <c>True</c>.
        /// To disable automatic model registration, set this value to <c>False</c>. If not specified,
        /// <c>AutomaticModelRegistration</c> defaults to <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutomaticModelRegistration { get; set; }
        #endregion
        
        #region Parameter MlflowVersion
        /// <summary>
        /// <para>
        /// <para>The version of MLflow that the tracking server uses. To see which MLflow versions
        /// are available to use, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/mlflow.html#mlflow-create-tracking-server-how-it-works">How
        /// it works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MlflowVersion { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for an IAM role in your account that the MLflow Tracking
        /// Server uses to access the artifact store in Amazon S3. The role should have <c>AmazonS3FullAccess</c>
        /// permissions. For more information on IAM permissions for tracking server creation,
        /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/mlflow-create-tracking-server-iam.html">Set
        /// up IAM permissions for MLflow</a>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags consisting of key-value pairs used to manage metadata for the tracking server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrackingServerName
        /// <summary>
        /// <para>
        /// <para>A unique string identifying the tracking server name. This string is part of the tracking
        /// server ARN.</para>
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
        /// <para>The size of the tracking server you want to create. You can choose between <c>"Small"</c>,
        /// <c>"Medium"</c>, and <c>"Large"</c>. The default MLflow Tracking Server configuration
        /// size is <c>"Small"</c>. You can choose a size depending on the projected use of the
        /// tracking server such as the volume of data logged, number of users, and frequency
        /// of use. </para><para>We recommend using a small tracking server for teams of up to 25 users, a medium tracking
        /// server for teams of up to 50 users, and a large tracking server for teams of up to
        /// 100 users. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TrackingServerSize")]
        public Amazon.SageMaker.TrackingServerSize TrackingServerSize { get; set; }
        #endregion
        
        #region Parameter WeeklyMaintenanceWindowStart
        /// <summary>
        /// <para>
        /// <para>The day and time of the week in Coordinated Universal Time (UTC) 24-hour standard
        /// time that weekly maintenance updates are scheduled. For example: TUE:03:30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WeeklyMaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrackingServerArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrackingServerArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackingServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMMlflowTrackingServer (CreateMlflowTrackingServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse, NewSMMlflowTrackingServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArtifactStoreUri = this.ArtifactStoreUri;
            #if MODULAR
            if (this.ArtifactStoreUri == null && ParameterWasBound(nameof(this.ArtifactStoreUri)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactStoreUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutomaticModelRegistration = this.AutomaticModelRegistration;
            context.MlflowVersion = this.MlflowVersion;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.SageMaker.Model.CreateMlflowTrackingServerRequest();
            
            if (cmdletContext.ArtifactStoreUri != null)
            {
                request.ArtifactStoreUri = cmdletContext.ArtifactStoreUri;
            }
            if (cmdletContext.AutomaticModelRegistration != null)
            {
                request.AutomaticModelRegistration = cmdletContext.AutomaticModelRegistration.Value;
            }
            if (cmdletContext.MlflowVersion != null)
            {
                request.MlflowVersion = cmdletContext.MlflowVersion;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateMlflowTrackingServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateMlflowTrackingServer");
            try
            {
                return client.CreateMlflowTrackingServerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MlflowVersion { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TrackingServerName { get; set; }
            public Amazon.SageMaker.TrackingServerSize TrackingServerSize { get; set; }
            public System.String WeeklyMaintenanceWindowStart { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateMlflowTrackingServerResponse, NewSMMlflowTrackingServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrackingServerArn;
        }
        
    }
}
