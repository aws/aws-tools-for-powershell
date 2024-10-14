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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Lists the Outposts for your Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// Use filters to return specific results. If you specify multiple filters, the results
    /// include only the resources that match all of the specified filters. For a filter where
    /// you can specify multiple values, the results include items that match any of the values
    /// that you specify for the filter.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "OUTPOutpostList")]
    [OutputType("Amazon.Outposts.Model.Outpost")]
    [AWSCmdlet("Calls the AWS Outposts ListOutposts API operation.", Operation = new[] {"ListOutposts"}, SelectReturnType = typeof(Amazon.Outposts.Model.ListOutpostsResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Outpost or Amazon.Outposts.Model.ListOutpostsResponse",
        "This cmdlet returns a collection of Amazon.Outposts.Model.Outpost objects.",
        "The service call response (type Amazon.Outposts.Model.ListOutpostsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOUTPOutpostListCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZoneFilter
        /// <summary>
        /// <para>
        /// <para>Filters the results by Availability Zone (for example, <c>us-east-1a</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AvailabilityZoneFilter { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneIdFilter
        /// <summary>
        /// <para>
        /// <para>Filters the results by AZ ID (for example, <c>use1-az1</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AvailabilityZoneIdFilter { get; set; }
        #endregion
        
        #region Parameter LifeCycleStatusFilter
        /// <summary>
        /// <para>
        /// <para>Filters the results by the lifecycle status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LifeCycleStatusFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Outposts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.ListOutpostsResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.ListOutpostsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Outposts";
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
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.ListOutpostsResponse, GetOUTPOutpostListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AvailabilityZoneFilter != null)
            {
                context.AvailabilityZoneFilter = new List<System.String>(this.AvailabilityZoneFilter);
            }
            if (this.AvailabilityZoneIdFilter != null)
            {
                context.AvailabilityZoneIdFilter = new List<System.String>(this.AvailabilityZoneIdFilter);
            }
            if (this.LifeCycleStatusFilter != null)
            {
                context.LifeCycleStatusFilter = new List<System.String>(this.LifeCycleStatusFilter);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Outposts.Model.ListOutpostsRequest();
            
            if (cmdletContext.AvailabilityZoneFilter != null)
            {
                request.AvailabilityZoneFilter = cmdletContext.AvailabilityZoneFilter;
            }
            if (cmdletContext.AvailabilityZoneIdFilter != null)
            {
                request.AvailabilityZoneIdFilter = cmdletContext.AvailabilityZoneIdFilter;
            }
            if (cmdletContext.LifeCycleStatusFilter != null)
            {
                request.LifeCycleStatusFilter = cmdletContext.LifeCycleStatusFilter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Outposts.Model.ListOutpostsResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.ListOutpostsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "ListOutposts");
            try
            {
                #if DESKTOP
                return client.ListOutposts(request);
                #elif CORECLR
                return client.ListOutpostsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AvailabilityZoneFilter { get; set; }
            public List<System.String> AvailabilityZoneIdFilter { get; set; }
            public List<System.String> LifeCycleStatusFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Outposts.Model.ListOutpostsResponse, GetOUTPOutpostListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Outposts;
        }
        
    }
}
