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
using Amazon.PCS;
using Amazon.PCS.Model;

namespace Amazon.PowerShell.Cmdlets.PCS
{
    /// <summary>
    /// Returns detailed information about a compute node group. This API action provides
    /// networking information, EC2 instance type, compute node group status, and scheduler
    /// (such as Slurm) configuration.
    /// </summary>
    [Cmdlet("Get", "PCSComputeNodeGroup")]
    [OutputType("Amazon.PCS.Model.ComputeNodeGroup")]
    [AWSCmdlet("Calls the AWS Parallel Computing Service GetComputeNodeGroup API operation.", Operation = new[] {"GetComputeNodeGroup"}, SelectReturnType = typeof(Amazon.PCS.Model.GetComputeNodeGroupResponse))]
    [AWSCmdletOutput("Amazon.PCS.Model.ComputeNodeGroup or Amazon.PCS.Model.GetComputeNodeGroupResponse",
        "This cmdlet returns an Amazon.PCS.Model.ComputeNodeGroup object.",
        "The service call response (type Amazon.PCS.Model.GetComputeNodeGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPCSComputeNodeGroupCmdlet : AmazonPCSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the cluster.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeNodeGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or ID of the compute node group.</para>
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
        public System.String ComputeNodeGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ComputeNodeGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PCS.Model.GetComputeNodeGroupResponse).
        /// Specifying the name of a property of type Amazon.PCS.Model.GetComputeNodeGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ComputeNodeGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputeNodeGroupIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputeNodeGroupIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputeNodeGroupIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PCS.Model.GetComputeNodeGroupResponse, GetPCSComputeNodeGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputeNodeGroupIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeNodeGroupIdentifier = this.ComputeNodeGroupIdentifier;
            #if MODULAR
            if (this.ComputeNodeGroupIdentifier == null && ParameterWasBound(nameof(this.ComputeNodeGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeNodeGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PCS.Model.GetComputeNodeGroupRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ComputeNodeGroupIdentifier != null)
            {
                request.ComputeNodeGroupIdentifier = cmdletContext.ComputeNodeGroupIdentifier;
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
        
        private Amazon.PCS.Model.GetComputeNodeGroupResponse CallAWSServiceOperation(IAmazonPCS client, Amazon.PCS.Model.GetComputeNodeGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Parallel Computing Service", "GetComputeNodeGroup");
            try
            {
                #if DESKTOP
                return client.GetComputeNodeGroup(request);
                #elif CORECLR
                return client.GetComputeNodeGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.String ComputeNodeGroupIdentifier { get; set; }
            public System.Func<Amazon.PCS.Model.GetComputeNodeGroupResponse, GetPCSComputeNodeGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ComputeNodeGroup;
        }
        
    }
}
