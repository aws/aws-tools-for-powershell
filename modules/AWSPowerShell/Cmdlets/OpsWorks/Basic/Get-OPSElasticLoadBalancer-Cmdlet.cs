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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describes a stack's Elastic Load Balancing instances.
    /// 
    ///  <note><para>
    /// This call accepts only one resource-identifying parameter.
    /// </para></note><para><b>Required Permissions</b>: To use this action, an IAM user must have a Show, Deploy,
    /// or Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information about user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OPSElasticLoadBalancer")]
    [OutputType("Amazon.OpsWorks.Model.ElasticLoadBalancer")]
    [AWSCmdlet("Calls the AWS OpsWorks DescribeElasticLoadBalancers API operation.", Operation = new[] {"DescribeElasticLoadBalancers"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse), LegacyAlias="Get-OPSElasticLoadBalancers")]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.ElasticLoadBalancer or Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse",
        "This cmdlet returns a collection of Amazon.OpsWorks.Model.ElasticLoadBalancer objects.",
        "The service call response (type Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOPSElasticLoadBalancerCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>A list of layer IDs. The action describes the Elastic Load Balancing instances for
        /// the specified layers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("LayerIds")]
        public System.String[] LayerId { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>A stack ID. The action describes the stack's Elastic Load Balancing instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ElasticLoadBalancers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ElasticLoadBalancers";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse, GetOPSElasticLoadBalancerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LayerId != null)
            {
                context.LayerId = new List<System.String>(this.LayerId);
            }
            context.StackId = this.StackId;
            
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
            var request = new Amazon.OpsWorks.Model.DescribeElasticLoadBalancersRequest();
            
            if (cmdletContext.LayerId != null)
            {
                request.LayerIds = cmdletContext.LayerId;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
        
        private Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.DescribeElasticLoadBalancersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "DescribeElasticLoadBalancers");
            try
            {
                return client.DescribeElasticLoadBalancersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> LayerId { get; set; }
            public System.String StackId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.DescribeElasticLoadBalancersResponse, GetOPSElasticLoadBalancerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ElasticLoadBalancers;
        }
        
    }
}
