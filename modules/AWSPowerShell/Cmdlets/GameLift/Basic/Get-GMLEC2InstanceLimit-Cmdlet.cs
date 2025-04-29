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
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves the instance limits and current utilization for an Amazon Web Services Region
    /// or location. Instance limits control the number of instances, per instance type, per
    /// location, that your Amazon Web Services account can use. Learn more at <a href="http://aws.amazon.com/ec2/instance-types/">Amazon
    /// EC2 Instance Types</a>. The information returned includes the maximum number of instances
    /// allowed and your account's current usage across all fleets. This information can affect
    /// your ability to scale your Amazon GameLift fleets. You can request a limit increase
    /// for your account by using the <b>Service limits</b> page in the Amazon GameLift console.
    /// 
    ///  
    /// <para>
    /// Instance limits differ based on whether the instances are deployed in a fleet's home
    /// Region or in a remote location. For remote locations, limits also differ based on
    /// the combination of home Region and remote location. All requests must specify an Amazon
    /// Web Services Region (either explicitly or as your default settings). To get the limit
    /// for a remote location, you must also specify the location. For example, the following
    /// requests all return different results: 
    /// </para><ul><li><para>
    /// Request specifies the Region <c>ap-northeast-1</c> with no location. The result is
    /// limits and usage data on all instance types that are deployed in <c>us-east-2</c>,
    /// by all of the fleets that reside in <c>ap-northeast-1</c>. 
    /// </para></li><li><para>
    /// Request specifies the Region <c>us-east-1</c> with location <c>ca-central-1</c>. The
    /// result is limits and usage data on all instance types that are deployed in <c>ca-central-1</c>,
    /// by all of the fleets that reside in <c>us-east-2</c>. These limits do not affect fleets
    /// in any other Regions that deploy instances to <c>ca-central-1</c>.
    /// </para></li><li><para>
    /// Request specifies the Region <c>eu-west-1</c> with location <c>ca-central-1</c>. The
    /// result is limits and usage data on all instance types that are deployed in <c>ca-central-1</c>,
    /// by all of the fleets that reside in <c>eu-west-1</c>.
    /// </para></li></ul><para>
    /// This operation can be used in the following ways:
    /// </para><ul><li><para>
    /// To get limit and usage data for all instance types that are deployed in an Amazon
    /// Web Services Region by fleets that reside in the same Region: Specify the Region only.
    /// Optionally, specify a single instance type to retrieve information for.
    /// </para></li><li><para>
    /// To get limit and usage data for all instance types that are deployed to a remote location
    /// by fleets that reside in different Amazon Web Services Region: Provide both the Amazon
    /// Web Services Region and the remote location. Optionally, specify a single instance
    /// type to retrieve information for.
    /// </para></li></ul><para>
    /// If successful, an <c>EC2InstanceLimits</c> object is returned with limits and usage
    /// data for each requested instance type.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up Amazon GameLift fleets</a></para>
    /// </summary>
    [Cmdlet("Get", "GMLEC2InstanceLimit")]
    [OutputType("Amazon.GameLift.Model.EC2InstanceLimit")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeEC2InstanceLimits API operation.", Operation = new[] {"DescribeEC2InstanceLimits"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.EC2InstanceLimit or Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.EC2InstanceLimit objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGMLEC2InstanceLimitCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>Name of an Amazon EC2 instance type that is supported in Amazon GameLift. A fleet
        /// instance type determines the computing resources of each instance in the fleet, including
        /// CPU, memory, storage, and networking capacity. Do not specify a value for this parameter
        /// to retrieve limits for all instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
        #endregion
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The name of a remote location to request instance limits for, in the form of an Amazon
        /// Web Services Region code such as <c>us-west-2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EC2InstanceLimits'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EC2InstanceLimits";
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse, GetGMLEC2InstanceLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EC2InstanceType = this.EC2InstanceType;
            context.Location = this.Location;
            
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
            var request = new Amazon.GameLift.Model.DescribeEC2InstanceLimitsRequest();
            
            if (cmdletContext.EC2InstanceType != null)
            {
                request.EC2InstanceType = cmdletContext.EC2InstanceType;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
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
        
        private Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeEC2InstanceLimitsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeEC2InstanceLimits");
            try
            {
                return client.DescribeEC2InstanceLimitsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public System.String Location { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse, GetGMLEC2InstanceLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EC2InstanceLimits;
        }
        
    }
}
