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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Forces a failover for a DB cluster.
    /// 
    ///  
    /// <para>
    /// A failover for a DB cluster promotes one of the Read Replicas (read-only instances)
    /// in the DB cluster to be the primary instance (the cluster writer).
    /// </para><para>
    /// Amazon Neptune will automatically fail over to a Read Replica, if one exists, when
    /// the primary instance fails. You can force a failover when you want to simulate a failure
    /// of a primary instance for testing. Because each instance in a DB cluster has its own
    /// endpoint address, you will need to clean up and re-establish any existing connections
    /// that use those endpoint addresses when the failover is complete.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "NPTDBClusterFailover", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Neptune FailoverDBCluster API operation.", Operation = new[] {"FailoverDBCluster"}, SelectReturnType = typeof(Amazon.Neptune.Model.FailoverDBClusterResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBCluster or Amazon.Neptune.Model.FailoverDBClusterResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBCluster object.",
        "The service call response (type Amazon.Neptune.Model.FailoverDBClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartNPTDBClusterFailoverCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>A DB cluster identifier to force a failover for. This parameter is not case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBCluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the instance to promote to the primary instance.</para><para>You must specify the instance identifier for an Read Replica in the DB cluster. For
        /// example, <c>mydbcluster-replica1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.FailoverDBClusterResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.FailoverDBClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NPTDBClusterFailover (FailoverDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.FailoverDBClusterResponse, StartNPTDBClusterFailoverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.TargetDBInstanceIdentifier = this.TargetDBInstanceIdentifier;
            
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
            var request = new Amazon.Neptune.Model.FailoverDBClusterRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.TargetDBInstanceIdentifier != null)
            {
                request.TargetDBInstanceIdentifier = cmdletContext.TargetDBInstanceIdentifier;
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
        
        private Amazon.Neptune.Model.FailoverDBClusterResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.FailoverDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "FailoverDBCluster");
            try
            {
                #if DESKTOP
                return client.FailoverDBCluster(request);
                #elif CORECLR
                return client.FailoverDBClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterIdentifier { get; set; }
            public System.String TargetDBInstanceIdentifier { get; set; }
            public System.Func<Amazon.Neptune.Model.FailoverDBClusterResponse, StartNPTDBClusterFailoverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
