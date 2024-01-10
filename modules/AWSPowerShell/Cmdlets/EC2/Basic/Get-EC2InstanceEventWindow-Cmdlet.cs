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
    /// Describes the specified event windows or all event windows.
    /// 
    ///  
    /// <para>
    /// If you specify event window IDs, the output includes information for only the specified
    /// event windows. If you specify filters, the output includes information for only those
    /// event windows that meet the filter criteria. If you do not specify event windows IDs
    /// or filters, the output includes information for all event windows, which can affect
    /// performance. We recommend that you use pagination to ensure that the operation returns
    /// quickly and successfully. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/event-windows.html">Define
    /// event windows for scheduled events</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceEventWindow")]
    [OutputType("Amazon.EC2.Model.InstanceEventWindow")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeInstanceEventWindows API operation.", Operation = new[] {"DescribeInstanceEventWindows"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeInstanceEventWindowsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceEventWindow or Amazon.EC2.Model.DescribeInstanceEventWindowsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceEventWindow objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstanceEventWindowsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2InstanceEventWindowCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>dedicated-host-id</c> - The event windows associated with the specified Dedicated
        /// Host ID.</para></li><li><para><c>event-window-name</c> - The event windows associated with the specified names.
        /// </para></li><li><para><c>instance-id</c> - The event windows associated with the specified instance ID.</para></li><li><para><c>instance-tag</c> - The event windows associated with the specified tag and value.</para></li><li><para><c>instance-tag-key</c> - The event windows associated with the specified tag key,
        /// regardless of the value.</para></li><li><para><c>instance-tag-value</c> - The event windows associated with the specified tag value,
        /// regardless of the key.</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the event
        /// window. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <c>Owner</c> and the
        /// value <c>CMX</c>, specify <c>tag:Owner</c> for the filter name and <c>CMX</c> for
        /// the filter value. </para></li><li><para><c>tag-key</c> - The key of a tag assigned to the event window. Use this filter to
        /// find all event windows that have a tag with a specific key, regardless of the tag
        /// value. </para></li><li><para><c>tag-value</c> - The value of a tag assigned to the event window. Use this filter
        /// to find all event windows that have a tag with a specific value, regardless of the
        /// tag key. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceEventWindowId
        /// <summary>
        /// <para>
        /// <para>The IDs of the event windows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceEventWindowIds")]
        public System.String[] InstanceEventWindowId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned <c>NextToken</c> value. This value can
        /// be between 20 and 500. You cannot specify this parameter and the event window IDs
        /// parameter in the same call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceEventWindows'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeInstanceEventWindowsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeInstanceEventWindowsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceEventWindows";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeInstanceEventWindowsResponse, GetEC2InstanceEventWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.InstanceEventWindowId != null)
            {
                context.InstanceEventWindowId = new List<System.String>(this.InstanceEventWindowId);
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
            var request = new Amazon.EC2.Model.DescribeInstanceEventWindowsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceEventWindowId != null)
            {
                request.InstanceEventWindowIds = cmdletContext.InstanceEventWindowId;
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
        
        private Amazon.EC2.Model.DescribeInstanceEventWindowsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeInstanceEventWindowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeInstanceEventWindows");
            try
            {
                #if DESKTOP
                return client.DescribeInstanceEventWindows(request);
                #elif CORECLR
                return client.DescribeInstanceEventWindowsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> InstanceEventWindowId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeInstanceEventWindowsResponse, GetEC2InstanceEventWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceEventWindows;
        }
        
    }
}
