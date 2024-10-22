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
    /// Describes the Regions that are enabled for your account, or all Regions.
    /// 
    ///  
    /// <para>
    /// For a list of the Regions supported by Amazon EC2, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-endpoints.html">Amazon
    /// EC2 service endpoints</a>.
    /// </para><para>
    /// For information about enabling and disabling Regions for your account, see <a href="https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-regions.html">Specify
    /// which Amazon Web Services Regions your account can use</a> in the <i>Amazon Web Services
    /// Account Management Reference Guide</i>.
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2Region")]
    [OutputType("Amazon.EC2.Model.Region")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeRegions API operation.", Operation = new[] {"DescribeRegions"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeRegionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Region or Amazon.EC2.Model.DescribeRegionsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Region objects.",
        "The service call response (type Amazon.EC2.Model.DescribeRegionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2RegionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllRegion
        /// <summary>
        /// <para>
        /// <para>Indicates whether to display all Regions, including Regions that are disabled for
        /// your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllRegions")]
        public System.Boolean? AllRegion { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>endpoint</c> - The endpoint of the Region (for example, <c>ec2.us-east-1.amazonaws.com</c>).</para></li><li><para><c>opt-in-status</c> - The opt-in status of the Region (<c>opt-in-not-required</c>
        /// | <c>opted-in</c> | <c>not-opted-in</c>).</para></li><li><para><c>region-name</c> - The name of the Region (for example, <c>us-east-1</c>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The names of the Regions. You can specify any Regions, whether they are enabled and
        /// disabled for your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("RegionNames")]
        public System.String[] RegionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Regions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeRegionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeRegionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Regions";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeRegionsResponse, GetEC2RegionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllRegion = this.AllRegion;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.RegionName != null)
            {
                context.RegionName = new List<System.String>(this.RegionName);
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
            var request = new Amazon.EC2.Model.DescribeRegionsRequest();
            
            if (cmdletContext.AllRegion != null)
            {
                request.AllRegions = cmdletContext.AllRegion.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionNames = cmdletContext.RegionName;
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
        
        private Amazon.EC2.Model.DescribeRegionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeRegionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeRegions");
            try
            {
                #if DESKTOP
                return client.DescribeRegions(request);
                #elif CORECLR
                return client.DescribeRegionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllRegion { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> RegionName { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeRegionsResponse, GetEC2RegionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Regions;
        }
        
    }
}
