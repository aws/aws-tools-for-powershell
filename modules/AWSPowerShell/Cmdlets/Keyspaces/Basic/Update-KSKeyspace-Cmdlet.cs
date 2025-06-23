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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// Adds a new Amazon Web Services Region to the keyspace. You can add a new Region to
    /// a keyspace that is either a single or a multi-Region keyspace. Amazon Keyspaces is
    /// going to replicate all tables in the keyspace to the new Region. To successfully replicate
    /// all tables to the new Region, they must use client-side timestamps for conflict resolution.
    /// To enable client-side timestamps, specify <c>clientSideTimestamps.status = enabled</c>
    /// when invoking the API. For more information about client-side timestamps, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/client-side-timestamps.html">Client-side
    /// timestamps in Amazon Keyspaces</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// To add a Region to a keyspace using the <c>UpdateKeyspace</c> API, the IAM principal
    /// needs permissions for the following IAM actions:
    /// </para><ul><li><para><c>cassandra:Alter</c></para></li><li><para><c>cassandra:AlterMultiRegionResource</c></para></li><li><para><c>cassandra:Create</c></para></li><li><para><c>cassandra:CreateMultiRegionResource</c></para></li><li><para><c>cassandra:Select</c></para></li><li><para><c>cassandra:SelectMultiRegionResource</c></para></li><li><para><c>cassandra:Modify</c></para></li><li><para><c>cassandra:ModifyMultiRegionResource</c></para></li></ul><para>
    /// If the keyspace contains a table that is configured in provisioned mode with auto
    /// scaling enabled, the following additional IAM actions need to be allowed.
    /// </para><ul><li><para><c>application-autoscaling:RegisterScalableTarget</c></para></li><li><para><c>application-autoscaling:DeregisterScalableTarget</c></para></li><li><para><c>application-autoscaling:DescribeScalableTargets</c></para></li><li><para><c>application-autoscaling:PutScalingPolicy</c></para></li><li><para><c>application-autoscaling:DescribeScalingPolicies</c></para></li></ul><para>
    /// To use the <c>UpdateKeyspace</c> API, the IAM principal also needs permissions to
    /// create a service-linked role with the following elements:
    /// </para><ul><li><para><c>iam:CreateServiceLinkedRole</c> - The <b>action</b> the principal can perform.
    /// </para></li><li><para><c>arn:aws:iam::*:role/aws-service-role/replication.cassandra.amazonaws.com/AWSServiceRoleForKeyspacesReplication</c>
    /// - The <b>resource</b> that the action can be performed on. 
    /// </para></li><li><para><c>iam:AWSServiceName: replication.cassandra.amazonaws.com</c> - The only Amazon
    /// Web Services service that this role can be attached to is Amazon Keyspaces.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/howitworks_replication_permissions_addReplica.html">Configure
    /// the IAM permissions required to add an Amazon Web Services Region to a keyspace</a>
    /// in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KSKeyspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces UpdateKeyspace API operation.", Operation = new[] {"UpdateKeyspace"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.UpdateKeyspaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.UpdateKeyspaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.UpdateKeyspaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKSKeyspaceCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para> The name of the keyspace. </para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter ReplicationSpecification_RegionList
        /// <summary>
        /// <para>
        /// <para> The <c>regionList</c> contains the Amazon Web Services Regions where the keyspace
        /// is replicated in. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicationSpecification_RegionList { get; set; }
        #endregion
        
        #region Parameter ReplicationSpecification_ReplicationStrategy
        /// <summary>
        /// <para>
        /// <para> The <c>replicationStrategy</c> of a keyspace, the required value is <c>SINGLE_REGION</c>
        /// or <c>MULTI_REGION</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Keyspaces.Rs")]
        public Amazon.Keyspaces.Rs ReplicationSpecification_ReplicationStrategy { get; set; }
        #endregion
        
        #region Parameter ClientSideTimestamps_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable client-side timestamps settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ClientSideTimestampsStatus")]
        public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.UpdateKeyspaceResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.UpdateKeyspaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyspaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KSKeyspace (UpdateKeyspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.UpdateKeyspaceResponse, UpdateKSKeyspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientSideTimestamps_Status = this.ClientSideTimestamps_Status;
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReplicationSpecification_RegionList != null)
            {
                context.ReplicationSpecification_RegionList = new List<System.String>(this.ReplicationSpecification_RegionList);
            }
            context.ReplicationSpecification_ReplicationStrategy = this.ReplicationSpecification_ReplicationStrategy;
            #if MODULAR
            if (this.ReplicationSpecification_ReplicationStrategy == null && ParameterWasBound(nameof(this.ReplicationSpecification_ReplicationStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationSpecification_ReplicationStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Keyspaces.Model.UpdateKeyspaceRequest();
            
            
             // populate ClientSideTimestamps
            var requestClientSideTimestampsIsNull = true;
            request.ClientSideTimestamps = new Amazon.Keyspaces.Model.ClientSideTimestamps();
            Amazon.Keyspaces.ClientSideTimestampsStatus requestClientSideTimestamps_clientSideTimestamps_Status = null;
            if (cmdletContext.ClientSideTimestamps_Status != null)
            {
                requestClientSideTimestamps_clientSideTimestamps_Status = cmdletContext.ClientSideTimestamps_Status;
            }
            if (requestClientSideTimestamps_clientSideTimestamps_Status != null)
            {
                request.ClientSideTimestamps.Status = requestClientSideTimestamps_clientSideTimestamps_Status;
                requestClientSideTimestampsIsNull = false;
            }
             // determine if request.ClientSideTimestamps should be set to null
            if (requestClientSideTimestampsIsNull)
            {
                request.ClientSideTimestamps = null;
            }
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            
             // populate ReplicationSpecification
            var requestReplicationSpecificationIsNull = true;
            request.ReplicationSpecification = new Amazon.Keyspaces.Model.ReplicationSpecification();
            List<System.String> requestReplicationSpecification_replicationSpecification_RegionList = null;
            if (cmdletContext.ReplicationSpecification_RegionList != null)
            {
                requestReplicationSpecification_replicationSpecification_RegionList = cmdletContext.ReplicationSpecification_RegionList;
            }
            if (requestReplicationSpecification_replicationSpecification_RegionList != null)
            {
                request.ReplicationSpecification.RegionList = requestReplicationSpecification_replicationSpecification_RegionList;
                requestReplicationSpecificationIsNull = false;
            }
            Amazon.Keyspaces.Rs requestReplicationSpecification_replicationSpecification_ReplicationStrategy = null;
            if (cmdletContext.ReplicationSpecification_ReplicationStrategy != null)
            {
                requestReplicationSpecification_replicationSpecification_ReplicationStrategy = cmdletContext.ReplicationSpecification_ReplicationStrategy;
            }
            if (requestReplicationSpecification_replicationSpecification_ReplicationStrategy != null)
            {
                request.ReplicationSpecification.ReplicationStrategy = requestReplicationSpecification_replicationSpecification_ReplicationStrategy;
                requestReplicationSpecificationIsNull = false;
            }
             // determine if request.ReplicationSpecification should be set to null
            if (requestReplicationSpecificationIsNull)
            {
                request.ReplicationSpecification = null;
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
        
        private Amazon.Keyspaces.Model.UpdateKeyspaceResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.UpdateKeyspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "UpdateKeyspace");
            try
            {
                return client.UpdateKeyspaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
            public System.String KeyspaceName { get; set; }
            public List<System.String> ReplicationSpecification_RegionList { get; set; }
            public Amazon.Keyspaces.Rs ReplicationSpecification_ReplicationStrategy { get; set; }
            public System.Func<Amazon.Keyspaces.Model.UpdateKeyspaceResponse, UpdateKSKeyspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceArn;
        }
        
    }
}
