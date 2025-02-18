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
    /// Creates a new DB shard group for Aurora Limitless Database. You must enable Aurora
    /// Limitless Database to create a DB shard group.
    /// 
    ///  
    /// <para>
    /// Valid for: Aurora DB clusters only
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSDBShardGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.CreateDBShardGroupResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBShardGroup API operation.", Operation = new[] {"CreateDBShardGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBShardGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.CreateDBShardGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.CreateDBShardGroupResponse object containing multiple properties."
    )]
    public partial class NewRDSDBShardGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeRedundancy
        /// <summary>
        /// <para>
        /// <para>Specifies whether to create standby DB shard groups for the DB shard group. Valid
        /// values are the following:</para><ul><li><para>0 - Creates a DB shard group without a standby DB shard group. This is the default
        /// value.</para></li><li><para>1 - Creates a DB shard group with a standby DB shard group in a different Availability
        /// Zone (AZ).</para></li><li><para>2 - Creates a DB shard group with two standby DB shard groups in two different AZs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeRedundancy { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the primary DB cluster for the DB shard group.</para>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBShardGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the DB shard group.</para>
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
        public System.String DBShardGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxACU
        /// <summary>
        /// <para>
        /// <para>The maximum capacity of the DB shard group in Aurora capacity units (ACUs).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? MaxACU { get; set; }
        #endregion
        
        #region Parameter MinACU
        /// <summary>
        /// <para>
        /// <para>The minimum capacity of the DB shard group in Aurora capacity units (ACUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MinACU { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB shard group is publicly accessible.</para><para>When the DB shard group is publicly accessible, its Domain Name System (DNS) endpoint
        /// resolves to the private IP address from within the DB shard group's virtual private
        /// cloud (VPC). It resolves to the public IP address from outside of the DB shard group's
        /// VPC. Access to the DB shard group is ultimately controlled by the security group it
        /// uses. That public access is not permitted if the security group assigned to the DB
        /// shard group doesn't permit it.</para><para>When the DB shard group isn't publicly accessible, it is an internal DB shard group
        /// with a DNS name that resolves to a private IP address.</para><para>Default: The default behavior varies depending on whether <c>DBSubnetGroupName</c>
        /// is specified.</para><para>If <c>DBSubnetGroupName</c> isn't specified, and <c>PubliclyAccessible</c> isn't specified,
        /// the following applies:</para><ul><li><para>If the default VPC in the target Region doesn’t have an internet gateway attached
        /// to it, the DB shard group is private.</para></li><li><para>If the default VPC in the target Region has an internet gateway attached to it, the
        /// DB shard group is public.</para></li></ul><para>If <c>DBSubnetGroupName</c> is specified, and <c>PubliclyAccessible</c> isn't specified,
        /// the following applies:</para><ul><li><para>If the subnets are part of a VPC that doesn’t have an internet gateway attached to
        /// it, the DB shard group is private.</para></li><li><para>If the subnets are part of a VPC that has an internet gateway attached to it, the
        /// DB shard group is public.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBShardGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBShardGroupResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBShardGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBShardGroup (CreateDBShardGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBShardGroupResponse, NewRDSDBShardGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeRedundancy = this.ComputeRedundancy;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBShardGroupIdentifier = this.DBShardGroupIdentifier;
            #if MODULAR
            if (this.DBShardGroupIdentifier == null && ParameterWasBound(nameof(this.DBShardGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBShardGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxACU = this.MaxACU;
            #if MODULAR
            if (this.MaxACU == null && ParameterWasBound(nameof(this.MaxACU)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxACU which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinACU = this.MinACU;
            context.PubliclyAccessible = this.PubliclyAccessible;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateDBShardGroupRequest();
            
            if (cmdletContext.ComputeRedundancy != null)
            {
                request.ComputeRedundancy = cmdletContext.ComputeRedundancy.Value;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBShardGroupIdentifier != null)
            {
                request.DBShardGroupIdentifier = cmdletContext.DBShardGroupIdentifier;
            }
            if (cmdletContext.MaxACU != null)
            {
                request.MaxACU = cmdletContext.MaxACU.Value;
            }
            if (cmdletContext.MinACU != null)
            {
                request.MinACU = cmdletContext.MinACU.Value;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
        
        private Amazon.RDS.Model.CreateDBShardGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBShardGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBShardGroup");
            try
            {
                return client.CreateDBShardGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ComputeRedundancy { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBShardGroupIdentifier { get; set; }
            public System.Double? MaxACU { get; set; }
            public System.Double? MinACU { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBShardGroupResponse, NewRDSDBShardGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
