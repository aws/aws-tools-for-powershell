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
    /// Describes attributes of your Amazon Web Services account. The following are the supported
    /// account attributes:
    /// 
    ///  <ul><li><para><c>default-vpc</c>: The ID of the default VPC for your account, or <c>none</c>.
    /// </para></li><li><para><c>max-instances</c>: This attribute is no longer supported. The returned value does
    /// not reflect your actual vCPU limit for running On-Demand Instances. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-on-demand-instances.html#ec2-on-demand-instances-limits">On-Demand
    /// Instance Limits</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para></li><li><para><c>max-elastic-ips</c>: The maximum number of Elastic IP addresses that you can allocate.
    /// </para></li><li><para><c>supported-platforms</c>: This attribute is deprecated.
    /// </para></li><li><para><c>vpc-max-elastic-ips</c>: The maximum number of Elastic IP addresses that you can
    /// allocate.
    /// </para></li><li><para><c>vpc-max-security-groups-per-interface</c>: The maximum number of security groups
    /// that you can assign to a network interface.
    /// </para></li></ul><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2AccountAttribute")]
    [OutputType("Amazon.EC2.Model.AccountAttribute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeAccountAttributes API operation.", Operation = new[] {"DescribeAccountAttributes"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeAccountAttributesResponse), LegacyAlias="Get-EC2AccountAttributes")]
    [AWSCmdletOutput("Amazon.EC2.Model.AccountAttribute or Amazon.EC2.Model.DescribeAccountAttributesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.AccountAttribute objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAccountAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2AccountAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The account attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AccountAttributeNames","AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountAttributes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeAccountAttributesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeAccountAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountAttributes";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeAccountAttributesResponse, GetEC2AccountAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
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
            var request = new Amazon.EC2.Model.DescribeAccountAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
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
        
        private Amazon.EC2.Model.DescribeAccountAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAccountAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeAccountAttributes");
            try
            {
                #if DESKTOP
                return client.DescribeAccountAttributes(request);
                #elif CORECLR
                return client.DescribeAccountAttributesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeName { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeAccountAttributesResponse, GetEC2AccountAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountAttributes;
        }
        
    }
}
