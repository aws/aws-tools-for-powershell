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
using Amazon.IoTTwinMaker;
using Amazon.IoTTwinMaker.Model;

namespace Amazon.PowerShell.Cmdlets.IOTTM
{
    /// <summary>
    /// Retrieves information about the history of a time series property value for a component,
    /// component type, entity, or workspace.
    /// 
    ///  
    /// <para>
    /// You must specify a value for <c>workspaceId</c>. For entity-specific queries, specify
    /// values for <c>componentName</c> and <c>entityId</c>. For cross-entity quries, specify
    /// a value for <c>componentTypeId</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTTMPropertyValueHistory")]
    [OutputType("Amazon.IoTTwinMaker.Model.PropertyValueHistory")]
    [AWSCmdlet("Calls the AWS IoT TwinMaker GetPropertyValueHistory API operation.", Operation = new[] {"GetPropertyValueHistory"}, SelectReturnType = typeof(Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse))]
    [AWSCmdletOutput("Amazon.IoTTwinMaker.Model.PropertyValueHistory or Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse",
        "This cmdlet returns a collection of Amazon.IoTTwinMaker.Model.PropertyValueHistory objects.",
        "The service call response (type Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTTMPropertyValueHistoryCmdlet : AmazonIoTTwinMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComponentName
        /// <summary>
        /// <para>
        /// <para>The name of the component.</para>
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
        /// <para>The ID of the component type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComponentTypeId { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The ISO8601 DateTime of the latest property value to return.</para><para>For more information about the ISO8601 DateTime format, see the data type <a href="https://docs.aws.amazon.com/iot-twinmaker/latest/apireference/API_PropertyValue.html">PropertyValue</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndTime { get; set; }
        #endregion
        
        #region Parameter EntityId
        /// <summary>
        /// <para>
        /// <para>The ID of the entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityId { get; set; }
        #endregion
        
        #region Parameter Interpolation_InterpolationType
        /// <summary>
        /// <para>
        /// <para>The interpolation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTTwinMaker.InterpolationType")]
        public Amazon.IoTTwinMaker.InterpolationType Interpolation_InterpolationType { get; set; }
        #endregion
        
        #region Parameter Interpolation_IntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The interpolation time interval in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Interpolation_IntervalInSeconds")]
        public System.Int64? Interpolation_IntervalInSecond { get; set; }
        #endregion
        
        #region Parameter OrderByTime
        /// <summary>
        /// <para>
        /// <para>The time direction to use in the result order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTTwinMaker.OrderByTime")]
        public Amazon.IoTTwinMaker.OrderByTime OrderByTime { get; set; }
        #endregion
        
        #region Parameter PropertyFilter
        /// <summary>
        /// <para>
        /// <para>A list of objects that filter the property value history request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropertyFilters")]
        public Amazon.IoTTwinMaker.Model.PropertyFilter[] PropertyFilter { get; set; }
        #endregion
        
        #region Parameter SelectedProperty
        /// <summary>
        /// <para>
        /// <para>A list of properties whose value histories the request retrieves.</para>
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
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The ISO8601 DateTime of the earliest property value to return.</para><para>For more information about the ISO8601 DateTime format, see the data type <a href="https://docs.aws.amazon.com/iot-twinmaker/latest/apireference/API_PropertyValue.html">PropertyValue</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartTime { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace.</para>
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
        
        #region Parameter EndDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time of the latest property value to return.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated and will throw an error in the future. Use endTime instead.")]
        public System.DateTime? EndDateTime { get; set; }
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
        
        #region Parameter StartDateTime
        /// <summary>
        /// <para>
        /// <para>The date and time of the earliest property value to return.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated and will throw an error in the future. Use startTime instead.")]
        public System.DateTime? StartDateTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PropertyValues'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse).
        /// Specifying the name of a property of type Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PropertyValues";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkspaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse, GetIOTTMPropertyValueHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkspaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComponentName = this.ComponentName;
            context.ComponentPath = this.ComponentPath;
            context.ComponentTypeId = this.ComponentTypeId;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndDateTime = this.EndDateTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            context.EntityId = this.EntityId;
            context.Interpolation_InterpolationType = this.Interpolation_InterpolationType;
            context.Interpolation_IntervalInSecond = this.Interpolation_IntervalInSecond;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OrderByTime = this.OrderByTime;
            if (this.PropertyFilter != null)
            {
                context.PropertyFilter = new List<Amazon.IoTTwinMaker.Model.PropertyFilter>(this.PropertyFilter);
            }
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StartDateTime = this.StartDateTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StartTime = this.StartTime;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryRequest();
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndDateTime != null)
            {
                request.EndDateTime = cmdletContext.EndDateTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime;
            }
            if (cmdletContext.EntityId != null)
            {
                request.EntityId = cmdletContext.EntityId;
            }
            
             // populate Interpolation
            var requestInterpolationIsNull = true;
            request.Interpolation = new Amazon.IoTTwinMaker.Model.InterpolationParameters();
            Amazon.IoTTwinMaker.InterpolationType requestInterpolation_interpolation_InterpolationType = null;
            if (cmdletContext.Interpolation_InterpolationType != null)
            {
                requestInterpolation_interpolation_InterpolationType = cmdletContext.Interpolation_InterpolationType;
            }
            if (requestInterpolation_interpolation_InterpolationType != null)
            {
                request.Interpolation.InterpolationType = requestInterpolation_interpolation_InterpolationType;
                requestInterpolationIsNull = false;
            }
            System.Int64? requestInterpolation_interpolation_IntervalInSecond = null;
            if (cmdletContext.Interpolation_IntervalInSecond != null)
            {
                requestInterpolation_interpolation_IntervalInSecond = cmdletContext.Interpolation_IntervalInSecond.Value;
            }
            if (requestInterpolation_interpolation_IntervalInSecond != null)
            {
                request.Interpolation.IntervalInSeconds = requestInterpolation_interpolation_IntervalInSecond.Value;
                requestInterpolationIsNull = false;
            }
             // determine if request.Interpolation should be set to null
            if (requestInterpolationIsNull)
            {
                request.Interpolation = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OrderByTime != null)
            {
                request.OrderByTime = cmdletContext.OrderByTime;
            }
            if (cmdletContext.PropertyFilter != null)
            {
                request.PropertyFilters = cmdletContext.PropertyFilter;
            }
            if (cmdletContext.SelectedProperty != null)
            {
                request.SelectedProperties = cmdletContext.SelectedProperty;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartDateTime != null)
            {
                request.StartDateTime = cmdletContext.StartDateTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime;
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
        
        private Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse CallAWSServiceOperation(IAmazonIoTTwinMaker client, Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT TwinMaker", "GetPropertyValueHistory");
            try
            {
                #if DESKTOP
                return client.GetPropertyValueHistory(request);
                #elif CORECLR
                return client.GetPropertyValueHistoryAsync(request).GetAwaiter().GetResult();
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
            public System.String ComponentName { get; set; }
            public System.String ComponentPath { get; set; }
            public System.String ComponentTypeId { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndDateTime { get; set; }
            public System.String EndTime { get; set; }
            public System.String EntityId { get; set; }
            public Amazon.IoTTwinMaker.InterpolationType Interpolation_InterpolationType { get; set; }
            public System.Int64? Interpolation_IntervalInSecond { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.IoTTwinMaker.OrderByTime OrderByTime { get; set; }
            public List<Amazon.IoTTwinMaker.Model.PropertyFilter> PropertyFilter { get; set; }
            public List<System.String> SelectedProperty { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartDateTime { get; set; }
            public System.String StartTime { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.IoTTwinMaker.Model.GetPropertyValueHistoryResponse, GetIOTTMPropertyValueHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PropertyValues;
        }
        
    }
}
