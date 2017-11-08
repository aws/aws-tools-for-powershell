/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DAX;
using Amazon.DAX.Model;

namespace Amazon.PowerShell.Cmdlets.DAX
{
    /// <summary>
    /// Adds one or more nodes to a DAX cluster.
    /// </summary>
    [Cmdlet("Set", "DAXReplicationFactorIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DAX.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon DynamoDB Accelerator (DAX) IncreaseReplicationFactor API operation.", Operation = new[] {"IncreaseReplicationFactor"})]
    [AWSCmdletOutput("Amazon.DAX.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.DAX.Model.IncreaseReplicationFactorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetDAXReplicationFactorIncreaseCmdlet : AmazonDAXClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zones (AZs) in which the cluster nodes will be created. All nodes
        /// belonging to the cluster are placed in these Availability Zones. Use this parameter
        /// if you want to distribute the nodes across multiple AZs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the DAX cluster that will receive additional nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter NewReplicationFactor
        /// <summary>
        /// <para>
        /// <para>The new number of nodes for the DAX cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewReplicationFactor { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-DAXReplicationFactorIncrease (IncreaseReplicationFactor)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            context.ClusterName = this.ClusterName;
            if (ParameterWasBound("NewReplicationFactor"))
                context.NewReplicationFactor = this.NewReplicationFactor;
            
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
            var request = new Amazon.DAX.Model.IncreaseReplicationFactorRequest();
            
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.NewReplicationFactor != null)
            {
                request.NewReplicationFactor = cmdletContext.NewReplicationFactor.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.DAX.Model.IncreaseReplicationFactorResponse CallAWSServiceOperation(IAmazonDAX client, Amazon.DAX.Model.IncreaseReplicationFactorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB Accelerator (DAX)", "IncreaseReplicationFactor");
            try
            {
                #if DESKTOP
                return client.IncreaseReplicationFactor(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.IncreaseReplicationFactorAsync(request);
                return task.Result;
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
            public List<System.String> AvailabilityZones { get; set; }
            public System.String ClusterName { get; set; }
            public System.Int32? NewReplicationFactor { get; set; }
        }
        
    }
}
