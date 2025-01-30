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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Returns AWS resources for this environment.
    /// </summary>
    [Cmdlet("Get", "EBEnvironmentResource")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EnvironmentResourceDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk DescribeEnvironmentResources API operation.", Operation = new[] {"DescribeEnvironmentResources"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse), LegacyAlias="Get-EBEnvironmentResources")]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EnvironmentResourceDescription or Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.EnvironmentResourceDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEBEnvironmentResourceCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to retrieve AWS resource usage data.</para><para> Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the environment to retrieve AWS resource usage data.</para><para> Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <c>MissingRequiredParameter</c> error.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentResources";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnvironmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse, GetEBEnvironmentResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnvironmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesRequest();
            
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
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
        
        private Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "DescribeEnvironmentResources");
            try
            {
                #if DESKTOP
                return client.DescribeEnvironmentResources(request);
                #elif CORECLR
                return client.DescribeEnvironmentResourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.DescribeEnvironmentResourcesResponse, GetEBEnvironmentResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentResources;
        }
        
    }
}
