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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Creates an enhanced snapshot of the state data of a running Managed Service for Apache
    /// Flink application. The application must be in the <c>RUNNING</c> status, use Apache
    /// Flink version 1.20 or later, and use the <c>ENHANCED_SNAPSHOTS</c> snapshot mode.
    /// 
    ///  
    /// <para>
    /// This operation is asynchronous. The response returns the snapshot ARN with the <c>CREATING</c>
    /// status. To check the status of the snapshot, use <c>DescribeSnapshot</c>. To track
    /// the progress of the operation, use <c>DescribeSnapshotOperation</c>.
    /// </para><para>
    /// An application can have only one <c>CreateSnapshot</c> operation in progress at a
    /// time. For information about limits, see <a href="https://docs.aws.amazon.com/managed-flink/latest/java/limits.html">Managed
    /// Service for Apache Flink Quotas</a>. For more information about snapshots, see <a href="https://docs.aws.amazon.com/managed-flink/latest/java/how-snapshots.html">Enhanced
    /// Snapshots</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINA2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 CreateSnapshot API operation.", Operation = new[] {"CreateSnapshot"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse",
        "This cmdlet returns an Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse object containing multiple properties."
    )]
    public partial class NewKINA2SnapshotCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter SnapshotDescription
        /// <summary>
        /// <para>
        /// <para>A summary description of the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotDescription { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of the enhanced snapshot. The name must be unique among the snapshots in
        /// your account and Region. You can't reuse the name of an existing snapshot, including
        /// a snapshot in the <c>FAILED</c> status, until you delete that snapshot. Names that
        /// begin with <c>SYSTEMSNAPSHOT</c> are reserved.</para>
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
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of one or more tags to assign to the snapshot. A tag is a key-value pair that
        /// identifies a snapshot. For more information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/java/how-tagging.html">Using
        /// Tagging</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisAnalyticsV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINA2Snapshot (CreateSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse, NewKINA2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotDescription = this.SnapshotDescription;
            context.SnapshotName = this.SnapshotName;
            #if MODULAR
            if (this.SnapshotName == null && ParameterWasBound(nameof(this.SnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisAnalyticsV2.Model.Tag>(this.Tag);
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
            var request = new Amazon.KinesisAnalyticsV2.Model.CreateSnapshotRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.SnapshotDescription != null)
            {
                request.SnapshotDescription = cmdletContext.SnapshotDescription;
            }
            if (cmdletContext.SnapshotName != null)
            {
                request.SnapshotName = cmdletContext.SnapshotName;
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
        
        private Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.CreateSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "CreateSnapshot");
            try
            {
                return client.CreateSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.String SnapshotDescription { get; set; }
            public System.String SnapshotName { get; set; }
            public List<Amazon.KinesisAnalyticsV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.CreateSnapshotResponse, NewKINA2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
