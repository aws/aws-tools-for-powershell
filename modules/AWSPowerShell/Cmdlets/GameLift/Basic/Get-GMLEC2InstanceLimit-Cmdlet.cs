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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves the following information for the specified EC2 instance type:
    /// 
    ///  <ul><li><para>
    /// Maximum number of instances allowed per AWS account (service limit).
    /// </para></li><li><para>
    /// Current usage for the AWS account.
    /// </para></li></ul><para>
    /// To learn more about the capabilities of each instance type, see <a href="http://aws.amazon.com/ec2/instance-types/">Amazon
    /// EC2 Instance Types</a>. Note that the instance types offered may vary depending on
    /// the region.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up GameLift Fleets</a></para><para><b>Related operations</b></para><ul><li><para><a>CreateFleet</a></para></li><li><para><a>ListFleets</a></para></li><li><para><a>DeleteFleet</a></para></li><li><para><a>DescribeFleetAttributes</a></para></li><li><para><a>UpdateFleetAttributes</a></para></li><li><para><a>StartFleetActions</a> or <a>StopFleetActions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLEC2InstanceLimit")]
    [OutputType("Amazon.GameLift.Model.EC2InstanceLimit")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeEC2InstanceLimits API operation.", Operation = new[] {"DescribeEC2InstanceLimits"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.EC2InstanceLimit or Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.EC2InstanceLimit objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLEC2InstanceLimitCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter EC2InstanceType
        /// <summary>
        /// <para>
        /// <para>Name of an EC2 instance type that is supported in Amazon GameLift. A fleet instance
        /// type determines the computing resources of each instance in the fleet, including CPU,
        /// memory, storage, and networking capacity. Amazon GameLift supports the following EC2
        /// instance types. See <a href="http://aws.amazon.com/ec2/instance-types/">Amazon EC2
        /// Instance Types</a> for detailed descriptions. Leave this parameter blank to retrieve
        /// limits for all types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.GameLift.EC2InstanceType")]
        public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EC2InstanceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EC2InstanceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EC2InstanceType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse, GetGMLEC2InstanceLimitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EC2InstanceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EC2InstanceType = this.EC2InstanceType;
            
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
                #if DESKTOP
                return client.DescribeEC2InstanceLimits(request);
                #elif CORECLR
                return client.DescribeEC2InstanceLimitsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GameLift.EC2InstanceType EC2InstanceType { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeEC2InstanceLimitsResponse, GetGMLEC2InstanceLimitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EC2InstanceLimits;
        }
        
    }
}
