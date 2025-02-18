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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Starts a database activity stream to monitor activity on the database. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/DBActivityStreams.html">
    /// Monitoring Amazon Aurora with Database Activity Streams</a> in the <i>Amazon Aurora
    /// User Guide</i> or <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/DBActivityStreams.html">
    /// Monitoring Amazon RDS with Database Activity Streams</a> in the <i>Amazon RDS User
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Start", "RDSActivityStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.StartActivityStreamResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service StartActivityStream API operation.", Operation = new[] {"StartActivityStream"}, SelectReturnType = typeof(Amazon.RDS.Model.StartActivityStreamResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.StartActivityStreamResponse",
        "This cmdlet returns an Amazon.RDS.Model.StartActivityStreamResponse object containing multiple properties."
    )]
    public partial class StartRDSActivityStreamCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the database activity stream is to start as soon as possible,
        /// regardless of the maintenance window for the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter EngineNativeAuditFieldsIncluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the database activity stream includes engine-native audit fields.
        /// This option applies to an Oracle or Microsoft SQL Server DB instance. By default,
        /// no engine-native audit fields are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EngineNativeAuditFieldsIncluded { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for encrypting messages in the database
        /// activity stream. The Amazon Web Services KMS key identifier is the key ARN, key ID,
        /// alias ARN, or alias name for the KMS key.</para>
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
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>Specifies the mode of the database activity stream. Database events such as a change
        /// or access generate an activity stream event. The database session can handle these
        /// events either synchronously or asynchronously.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.RDS.ActivityStreamMode")]
        public Amazon.RDS.ActivityStreamMode Mode { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the DB cluster, for example, <c>arn:aws:rds:us-east-1:12345667890:cluster:das-cluster</c>.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.StartActivityStreamResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.StartActivityStreamResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSActivityStream (StartActivityStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.StartActivityStreamResponse, StartRDSActivityStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            context.EngineNativeAuditFieldsIncluded = this.EngineNativeAuditFieldsIncluded;
            context.KmsKeyId = this.KmsKeyId;
            #if MODULAR
            if (this.KmsKeyId == null && ParameterWasBound(nameof(this.KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mode = this.Mode;
            #if MODULAR
            if (this.Mode == null && ParameterWasBound(nameof(this.Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.StartActivityStreamRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.EngineNativeAuditFieldsIncluded != null)
            {
                request.EngineNativeAuditFieldsIncluded = cmdletContext.EngineNativeAuditFieldsIncluded.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.RDS.Model.StartActivityStreamResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.StartActivityStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "StartActivityStream");
            try
            {
                return client.StartActivityStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? EngineNativeAuditFieldsIncluded { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.RDS.ActivityStreamMode Mode { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.RDS.Model.StartActivityStreamResponse, StartRDSActivityStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
