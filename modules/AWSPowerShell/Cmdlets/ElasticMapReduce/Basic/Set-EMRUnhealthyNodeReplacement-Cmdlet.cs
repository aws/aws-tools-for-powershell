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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Specify whether to enable unhealthy node replacement, which lets Amazon EMR gracefully
    /// replace core nodes on a cluster if any nodes become unhealthy. For example, a node
    /// becomes unhealthy if disk usage is above 90%. If unhealthy node replacement is on
    /// and <c>TerminationProtected</c> are off, Amazon EMR immediately terminates the unhealthy
    /// core nodes. To use unhealthy node replacement and retain unhealthy core nodes, use
    /// to turn on termination protection. In such cases, Amazon EMR adds the unhealthy nodes
    /// to a denylist, reducing job interruptions and failures.
    /// 
    ///  
    /// <para>
    /// If unhealthy node replacement is on, Amazon EMR notifies YARN and other applications
    /// on the cluster to stop scheduling tasks with these nodes, moves the data, and then
    /// terminates the nodes.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-plan-node-replacement.html">graceful
    /// node replacement</a> in the <i>Amazon EMR Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "EMRUnhealthyNodeReplacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce SetUnhealthyNodeReplacement API operation.", Operation = new[] {"SetUnhealthyNodeReplacement"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEMRUnhealthyNodeReplacementCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para>The list of strings that uniquely identify the clusters for which to turn on unhealthy
        /// node replacement. You can get these identifiers by running the <a>RunJobFlow</a> or
        /// the <a>DescribeJobFlows</a> operations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("JobFlowIds")]
        public System.String[] JobFlowId { get; set; }
        #endregion
        
        #region Parameter UnhealthyNodeReplacement
        /// <summary>
        /// <para>
        /// <para>Indicates whether to turn on or turn off graceful unhealthy node replacement.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? UnhealthyNodeReplacement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UnhealthyNodeReplacement parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UnhealthyNodeReplacement' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UnhealthyNodeReplacement' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UnhealthyNodeReplacement), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EMRUnhealthyNodeReplacement (SetUnhealthyNodeReplacement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse, SetEMRUnhealthyNodeReplacementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UnhealthyNodeReplacement;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.JobFlowId != null)
            {
                context.JobFlowId = new List<System.String>(this.JobFlowId);
            }
            #if MODULAR
            if (this.JobFlowId == null && ParameterWasBound(nameof(this.JobFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnhealthyNodeReplacement = this.UnhealthyNodeReplacement;
            #if MODULAR
            if (this.UnhealthyNodeReplacement == null && ParameterWasBound(nameof(this.UnhealthyNodeReplacement)))
            {
                WriteWarning("You are passing $null as a value for parameter UnhealthyNodeReplacement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementRequest();
            
            if (cmdletContext.JobFlowId != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowId;
            }
            if (cmdletContext.UnhealthyNodeReplacement != null)
            {
                request.UnhealthyNodeReplacement = cmdletContext.UnhealthyNodeReplacement.Value;
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
        
        private Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "SetUnhealthyNodeReplacement");
            try
            {
                #if DESKTOP
                return client.SetUnhealthyNodeReplacement(request);
                #elif CORECLR
                return client.SetUnhealthyNodeReplacementAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> JobFlowId { get; set; }
            public System.Boolean? UnhealthyNodeReplacement { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.SetUnhealthyNodeReplacementResponse, SetEMRUnhealthyNodeReplacementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
