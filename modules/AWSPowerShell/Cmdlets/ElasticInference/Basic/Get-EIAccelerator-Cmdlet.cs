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
    /// <note><para>
    /// Amazon Elastic Inference is no longer available.
    /// </para></note><para>
    ///  Describes information over a provided set of accelerators belonging to an account.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EIAccelerator")]
    [OutputType("Amazon.ElasticInference.Model.ElasticInferenceAccelerator")]
    [AWSCmdlet("Calls the Amazon Elastic Inference DescribeAccelerators API operation.", Operation = new[] {"DescribeAccelerators"}, SelectReturnType = typeof(Amazon.ElasticInference.Model.DescribeAcceleratorsResponse))]
    [AWSCmdletOutput("Amazon.ElasticInference.Model.ElasticInferenceAccelerator or Amazon.ElasticInference.Model.DescribeAcceleratorsResponse",
        "This cmdlet returns a collection of Amazon.ElasticInference.Model.ElasticInferenceAccelerator objects.",
        "The service call response (type Amazon.ElasticInference.Model.DescribeAcceleratorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEIAcceleratorCmdlet : AmazonElasticInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceleratorId
        /// <summary>
        /// <para>
        /// <para> The IDs of the accelerators to describe. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceleratorIds")]
        public System.String[] AcceleratorId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> One or more filters. Filter names and values are case-sensitive. Valid filter names
        /// are: accelerator-types: can provide a list of accelerator type names to filter for.
        /// instance-id: can provide a list of EC2 instance ids to filter for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ElasticInference.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The total number of items to return in the command's output. If the total number
        /// of items available is more than the value specified, a NextToken is provided in the
        /// command's output. To resume pagination, provide the NextToken value in the starting-token
        /// argument of a subsequent command. Do not use the NextToken response element directly
        /// outside of the AWS CLI. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A token to specify where to start paginating. This is the NextToken from a previously
        /// truncated response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcceleratorSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticInference.Model.DescribeAcceleratorsResponse).
        /// Specifying the name of a property of type Amazon.ElasticInference.Model.DescribeAcceleratorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcceleratorSet";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticInference.Model.DescribeAcceleratorsResponse, GetEIAcceleratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AcceleratorId != null)
            {
                context.AcceleratorId = new List<System.String>(this.AcceleratorId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ElasticInference.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ElasticInference.Model.DescribeAcceleratorsRequest();
            
            if (cmdletContext.AcceleratorId != null)
            {
                request.AcceleratorIds = cmdletContext.AcceleratorId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.ElasticInference.Model.DescribeAcceleratorsResponse CallAWSServiceOperation(IAmazonElasticInference client, Amazon.ElasticInference.Model.DescribeAcceleratorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Inference", "DescribeAccelerators");
            try
            {
                #if DESKTOP
                return client.DescribeAccelerators(request);
                #elif CORECLR
                return client.DescribeAcceleratorsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AcceleratorId { get; set; }
            public List<Amazon.ElasticInference.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ElasticInference.Model.DescribeAcceleratorsResponse, GetEIAcceleratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcceleratorSet;
        }
        
    }
}
