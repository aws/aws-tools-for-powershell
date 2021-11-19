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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a public IPv4 address pool. A public IPv4 pool is an EC2 IP address pool required
    /// for the public IPv4 CIDRs that you own and bring to Amazon Web Services to manage
    /// with IPAM. IPv6 addresses you bring to Amazon Web Services, however, use IPAM pools
    /// only. To monitor the status of pool creation, use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribePublicIpv4Pools.html">DescribePublicIpv4Pools</a>.
    /// </summary>
    [Cmdlet("New", "EC2PublicIpv4Pool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreatePublicIpv4Pool API operation.", Operation = new[] {"CreatePublicIpv4Pool"}, SelectReturnType = typeof(Amazon.EC2.Model.CreatePublicIpv4PoolResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.CreatePublicIpv4PoolResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.CreatePublicIpv4PoolResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2PublicIpv4PoolCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key/value combination of a tag assigned to the resource. Use the tag key in the
        /// filter name and the tag value as the filter value. For example, to find all resources
        /// that have a tag with the key <code>Owner</code> and the value <code>TeamA</code>,
        /// specify <code>tag:Owner</code> for the filter name and <code>TeamA</code> for the
        /// filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PoolId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreatePublicIpv4PoolResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreatePublicIpv4PoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PoolId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TagSpecification), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2PublicIpv4Pool (CreatePublicIpv4Pool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreatePublicIpv4PoolResponse, NewEC2PublicIpv4PoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreatePublicIpv4PoolRequest();
            
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreatePublicIpv4PoolResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreatePublicIpv4PoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreatePublicIpv4Pool");
            try
            {
                #if DESKTOP
                return client.CreatePublicIpv4Pool(request);
                #elif CORECLR
                return client.CreatePublicIpv4PoolAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreatePublicIpv4PoolResponse, NewEC2PublicIpv4PoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PoolId;
        }
        
    }
}
