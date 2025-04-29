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
using Amazon.IoTTwinMaker;
using Amazon.IoTTwinMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTTM
{
    /// <summary>
    /// Gets the property values for a component, component type, entity, or workspace.
    /// 
    ///  
    /// <para>
    /// You must specify a value for either <c>componentName</c>, <c>componentTypeId</c>,
    /// <c>entityId</c>, or <c>workspaceId</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTTMPropertyValue")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker GetPropertyValue API operation.", Operation = new[] {"GetPropertyValue"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.GetPropertyValueResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTTwinMaker.Model.GetPropertyValueResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.IoTTwinMaker.Model.GetPropertyValueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTTMPropertyValueCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component whose property values the operation returns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentName { get; set; }
        #endregion
        
        #region Parameter ComponentPath
        /// <summary>
        /// <para>
        /// <para>This string specifies the path to the composite component, starting from the top-level
        /// component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentPath { get; set; }
        #endregion
        
        #region Parameter ComponentTypeId
        /// <summary>
        /// <para>
        /// <para>The ID of the component type whose property values the operation returns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentTypeId { get; set; }
        #endregion
        
        #region Parameter EntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the entity whose property values the operation returns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter TabularConditions_OrderBy
        /// <summary>
        /// <para>
        /// <para>Filter criteria that orders the output. It can be sorted in ascending or descending
        /// order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTTwinMaker.Model.OrderBy[] TabularConditions_OrderBy { get; set; }
        #endregion
        
        #region Parameter TabularConditions_PropertyFilter
        /// <summary>
        /// <para>
        /// <para>You can filter the request using various logical operators and a key-value format.
        /// For example:</para><para><c>{"key": "serverType", "value": "webServer"}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TabularConditions_PropertyFilters")]
        public Amazon.IoTTwinMaker.Model.PropertyFilter[] TabularConditions_PropertyFilter { get; set; }
        #endregion
        
        #region Parameter PropertyGroupName
        /// <summary>
        /// <para>
        /// <para>The property group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyGroupName { get; set; }
        #endregion
        
        #region Parameter SelectedProperty
        /// <summary>
        /// <para>
        /// <para>The properties whose values the operation returns.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SelectedProperties")]
        public System.String[] SelectedProperty { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace whose values the operation returns.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return at one time. The default is 25.</para><para>Valid Range: Minimum value of 1. Maximum value of 250.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The string that specifies the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PropertyValues'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.GetPropertyValueResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.GetPropertyValueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PropertyValues";
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
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.GetPropertyValueResponse, GetIOTTMPropertyValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComponentName = this.ComponentName;
            context.ComponentPath = this.ComponentPath;
            context.ComponentTypeId = this.ComponentTypeId;
            context.EntityId = this.EntityId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PropertyGroupName = this.PropertyGroupName;
            if (this.SelectedProperty != null)
            {
                context.SelectedProperty = new List<System.String>(this.SelectedProperty);
            }
            #if MODULAR
            if (this.SelectedProperty == null && ParameterWasBound(nameof(this.SelectedProperty)))
            {
                WriteWarning("You are passing $null as a value for parameter SelectedProperty which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TabularConditions_OrderBy != null)
            {
                context.TabularConditions_OrderBy = new List<Amazon.IoTTwinMaker.Model.OrderBy>(this.TabularConditions_OrderBy);
            }
            if (this.TabularConditions_PropertyFilter != null)
            {
                context.TabularConditions_PropertyFilter = new List<Amazon.IoTTwinMaker.Model.PropertyFilter>(this.TabularConditions_PropertyFilter);
            }
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.IoTTwinMaker.Model.GetPropertyValueRequest();
            
            if (cmdletContext.ComponentName != null)
            {
                request.ComponentName = cmdletContext.ComponentName;
            }
            if (cmdletContext.ComponentPath != null)
            {
                request.ComponentPath = cmdletContext.ComponentPath;
            }
            if (cmdletContext.ComponentTypeId != null)
            {
                request.ComponentTypeId = cmdletContext.ComponentTypeId;
            }
            if (cmdletContext.EntityId != null)
            {
                request.EntityId = cmdletContext.EntityId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PropertyGroupName != null)
            {
                request.PropertyGroupName = cmdletContext.PropertyGroupName;
            }
            if (cmdletContext.SelectedProperty != null)
            {
                request.SelectedProperties = cmdletContext.SelectedProperty;
            }
            
             // populate TabularConditions
            var requestTabularConditionsIsNull = true;
            request.TabularConditions = new Amazon.IoTTwinMaker.Model.TabularConditions();
            List<Amazon.IoTTwinMaker.Model.OrderBy> requestTabularConditions_tabularConditions_OrderBy = null;
            if (cmdletContext.TabularConditions_OrderBy != null)
            {
                requestTabularConditions_tabularConditions_OrderBy = cmdletContext.TabularConditions_OrderBy;
            }
            if (requestTabularConditions_tabularConditions_OrderBy != null)
            {
                request.TabularConditions.OrderBy = requestTabularConditions_tabularConditions_OrderBy;
                requestTabularConditionsIsNull = false;
            }
            List<Amazon.IoTTwinMaker.Model.PropertyFilter> requestTabularConditions_tabularConditions_PropertyFilter = null;
            if (cmdletContext.TabularConditions_PropertyFilter != null)
            {
                requestTabularConditions_tabularConditions_PropertyFilter = cmdletContext.TabularConditions_PropertyFilter;
            }
            if (requestTabularConditions_tabularConditions_PropertyFilter != null)
            {
                request.TabularConditions.PropertyFilters = requestTabularConditions_tabularConditions_PropertyFilter;
                requestTabularConditionsIsNull = false;
            }
             // determine if request.TabularConditions should be set to null
            if (requestTabularConditionsIsNull)
            {
                request.TabularConditions = null;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.IoTTwinMaker.Model.GetPropertyValueResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.GetPropertyValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "GetPropertyValue");
            try
            {
                return client.GetPropertyValueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ComponentName { get; set; }
            public System.String ComponentPath { get; set; }
            public System.String ComponentTypeId { get; set; }
            public System.String EntityId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PropertyGroupName { get; set; }
            public List<System.String> SelectedProperty { get; set; }
            public List<Amazon.IoTTwinMaker.Model.OrderBy> TabularConditions_OrderBy { get; set; }
            public List<Amazon.IoTTwinMaker.Model.PropertyFilter> TabularConditions_PropertyFilter { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.GetPropertyValueResponse, GetIOTTMPropertyValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PropertyValues;
        }
        
    }
}
