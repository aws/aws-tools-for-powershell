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
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Creates a backup access point for an Amazon S3 recovery point. A backup access point
    /// provides on-demand, read-only access to the backup data in a recovery point through
    /// an Amazon S3 access point, without initiating a restore.
    /// 
    ///  
    /// <para>
    /// While a backup access point is active for a recovery point, Backup pauses lifecycle
    /// transitions and blocks deletion of that recovery point.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BAKBackupAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateBackupAccessPointResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateBackupAccessPoint API operation.", Operation = new[] {"CreateBackupAccessPoint"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateBackupAccessPointResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateBackupAccessPointResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateBackupAccessPointResponse object containing multiple properties."
    )]
    public partial class NewBAKBackupAccessPointCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessPointMetadata
        /// <summary>
        /// <para>
        /// <para>Metadata for the backup access point. For continuous (point-in-time) recovery points,
        /// you must include an <c>AccessPointInTime</c> timestamp (in format <c>2021-11-27T03:30:27Z</c>).
        /// The access point provides access to the content present in the backup at that specific
        /// time. You can specify any time within the continuous backup's retention period, up
        /// to the latest restorable time. For snapshot recovery points, do not include <c>AccessPointInTime</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AccessPointMetadata { get; set; }
        #endregion
        
        #region Parameter AccessPointPolicy
        /// <summary>
        /// <para>
        /// <para>An optional resource-based policy, in JSON format, to apply to the underlying Amazon
        /// S3 access point. The policy controls how backup data can be accessed through the access
        /// point. If you do not specify a policy, access is governed by the caller's IAM permissions.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-policies.html">Configuring
        /// IAM policies for using access points</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessPointPolicy { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the backup access point. This name is shared with the Amazon S3 access
        /// point namespace. It must be unique within your account and Region and cannot conflict
        /// with an existing Amazon S3 access point. For more information about access point naming,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-restrictions-limitations-naming-rules.html">Access
        /// points naming rules, restrictions, and limitations</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recovery point for which to create the backup
        /// access point. The recovery point must be an Amazon S3 recovery point in the <c>AVAILABLE</c>,
        /// <c>STOPPED</c>, or <c>COMPLETED</c> state.</para>
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
        public System.String RecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the backup access point.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateBackupAccessPointResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateBackupAccessPointResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.RecoveryPointArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKBackupAccessPoint (CreateBackupAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateBackupAccessPointResponse, NewBAKBackupAccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessPointMetadata != null)
            {
                context.AccessPointMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AccessPointMetadata.Keys)
                {
                    context.AccessPointMetadata.Add((String)hashKey, (System.String)(this.AccessPointMetadata[hashKey]));
                }
            }
            context.AccessPointPolicy = this.AccessPointPolicy;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecoveryPointArn = this.RecoveryPointArn;
            #if MODULAR
            if (this.RecoveryPointArn == null && ParameterWasBound(nameof(this.RecoveryPointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Backup.Model.CreateBackupAccessPointRequest();
            
            if (cmdletContext.AccessPointMetadata != null)
            {
                request.AccessPointMetadata = cmdletContext.AccessPointMetadata;
            }
            if (cmdletContext.AccessPointPolicy != null)
            {
                request.AccessPointPolicy = cmdletContext.AccessPointPolicy;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RecoveryPointArn != null)
            {
                request.RecoveryPointArn = cmdletContext.RecoveryPointArn;
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
        
        private Amazon.Backup.Model.CreateBackupAccessPointResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateBackupAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateBackupAccessPoint");
            try
            {
                return client.CreateBackupAccessPointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AccessPointMetadata { get; set; }
            public System.String AccessPointPolicy { get; set; }
            public System.String Name { get; set; }
            public System.String RecoveryPointArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Backup.Model.CreateBackupAccessPointResponse, NewBAKBackupAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
