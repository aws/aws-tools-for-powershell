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
using Amazon.Synthetics;
using Amazon.Synthetics.Model;

namespace Amazon.PowerShell.Cmdlets.CWSYN
{
    /// <summary>
    /// Use this operation to see information from the most recent run of each canary that
    /// you have created.
    /// 
    ///  
    /// <para>
    /// This operation supports resource-level authorization using an IAM policy and the <c>Names</c>
    /// parameter. If you specify the <c>Names</c> parameter, the operation is successful
    /// only if you have authorization to view all the canaries that you specify in your request.
    /// If you do not have permission to view any of the canaries, the request fails with
    /// a 403 response.
    /// </para><para>
    /// You are required to use the <c>Names</c> parameter if you are logged on to a user
    /// or role that has an IAM policy that restricts which canaries that you are allowed
    /// to view. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_Restricted.html">
    /// Limiting a user to viewing specific canaries</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWSYNCanariesLastRun")]
    [OutputType("Amazon.Synthetics.Model.CanaryLastRun")]
    [AWSCmdlet("Calls the Amazon CloudWatch Synthetics DescribeCanariesLastRun API operation.", Operation = new[] {"DescribeCanariesLastRun"}, SelectReturnType = typeof(Amazon.Synthetics.Model.DescribeCanariesLastRunResponse))]
    [AWSCmdletOutput("Amazon.Synthetics.Model.CanaryLastRun or Amazon.Synthetics.Model.DescribeCanariesLastRunResponse",
        "This cmdlet returns a collection of Amazon.Synthetics.Model.CanaryLastRun objects.",
        "The service call response (type Amazon.Synthetics.Model.DescribeCanariesLastRunResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWSYNCanariesLastRunCmdlet : AmazonSyntheticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BrowserType
        /// <summary>
        /// <para>
        /// <para>The type of browser to use for the canary run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Synthetics.BrowserType")]
        public Amazon.Synthetics.BrowserType BrowserType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Use this parameter to return only canaries that match the names that you specify here.
        /// You can specify as many as five canary names.</para><para>If you specify this parameter, the operation is successful only if you have authorization
        /// to view all the canaries that you specify in your request. If you do not have permission
        /// to view any of the canaries, the request fails with a 403 response.</para><para>You are required to use the <c>Names</c> parameter if you are logged on to a user
        /// or role that has an IAM policy that restricts which canaries that you are allowed
        /// to view. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_Restricted.html">
        /// Limiting a user to viewing specific canaries</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Names")]
        public System.String[] Name { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specify this parameter to limit how many runs are returned each time you use the <c>DescribeLastRun</c>
        /// operation. If you omit this parameter, the default of 100 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates that there is more data available. You can use this token in
        /// a subsequent <c>DescribeCanariesLastRun</c> operation to retrieve the next set of
        /// results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CanariesLastRun'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Synthetics.Model.DescribeCanariesLastRunResponse).
        /// Specifying the name of a property of type Amazon.Synthetics.Model.DescribeCanariesLastRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CanariesLastRun";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Synthetics.Model.DescribeCanariesLastRunResponse, GetCWSYNCanariesLastRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrowserType = this.BrowserType;
            context.MaxResult = this.MaxResult;
            if (this.Name != null)
            {
                context.Name = new List<System.String>(this.Name);
            }
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Synthetics.Model.DescribeCanariesLastRunRequest();
            
            if (cmdletContext.BrowserType != null)
            {
                request.BrowserType = cmdletContext.BrowserType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Names = cmdletContext.Name;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Synthetics.Model.DescribeCanariesLastRunResponse CallAWSServiceOperation(IAmazonSynthetics client, Amazon.Synthetics.Model.DescribeCanariesLastRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Synthetics", "DescribeCanariesLastRun");
            try
            {
                #if DESKTOP
                return client.DescribeCanariesLastRun(request);
                #elif CORECLR
                return client.DescribeCanariesLastRunAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Synthetics.BrowserType BrowserType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> Name { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Synthetics.Model.DescribeCanariesLastRunResponse, GetCWSYNCanariesLastRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CanariesLastRun;
        }
        
    }
}
