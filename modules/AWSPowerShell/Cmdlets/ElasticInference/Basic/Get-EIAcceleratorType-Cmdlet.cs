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
using Amazon.ElasticInference;
using Amazon.ElasticInference.Model;

namespace Amazon.PowerShell.Cmdlets.EI
{
    /// <summary>
    /// Describes the accelerator types available in a given region, as well as their characteristics,
    /// such as memory and throughput. 
    /// 
    ///  
    /// <para>
    ///  February 15, 2023: Starting April 15, 2023, AWS will not onboard new customers to
    /// Amazon Elastic Inference (EI), and will help current customers migrate their workloads
    /// to options that offer better price and performance. After April 15, 2023, new customers
    /// will not be able to launch instances with Amazon EI accelerators in Amazon SageMaker,
    /// Amazon ECS, or Amazon EC2. However, customers who have used Amazon EI at least once
    /// during the past 30-day period are considered current customers and will be able to
    /// continue using the service. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EIAcceleratorType")]
    [OutputType("Amazon.ElasticInference.Model.AcceleratorType")]
    [AWSCmdlet("Calls the Amazon Elastic Inference DescribeAcceleratorTypes API operation.", Operation = new[] {"DescribeAcceleratorTypes"}, SelectReturnType = typeof(Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse))]
    [AWSCmdletOutput("Amazon.ElasticInference.Model.AcceleratorType or Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse",
        "This cmdlet returns a collection of Amazon.ElasticInference.Model.AcceleratorType objects.",
        "The service call response (type Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEIAcceleratorTypeCmdlet : AmazonElasticInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcceleratorTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse).
        /// Specifying the name of a property of type Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcceleratorTypes";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse, GetEIAcceleratorTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.ElasticInference.Model.DescribeAcceleratorTypesRequest();
            
            
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
        
        private Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse CallAWSServiceOperation(IAmazonElasticInference client, Amazon.ElasticInference.Model.DescribeAcceleratorTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Inference", "DescribeAcceleratorTypes");
            try
            {
                #if DESKTOP
                return client.DescribeAcceleratorTypes(request);
                #elif CORECLR
                return client.DescribeAcceleratorTypesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElasticInference.Model.DescribeAcceleratorTypesResponse, GetEIAcceleratorTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcceleratorTypes;
        }
        
    }
}
