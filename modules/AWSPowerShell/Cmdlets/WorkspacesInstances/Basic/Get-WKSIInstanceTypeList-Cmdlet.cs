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
using Amazon.WorkspacesInstances;
using Amazon.WorkspacesInstances.Model;

namespace Amazon.PowerShell.Cmdlets.WKSI
{
    /// <summary>
    /// Retrieves a list of instance types supported by Amazon WorkSpaces Instances, enabling
    /// precise workspace infrastructure configuration.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WKSIInstanceTypeList")]
    [OutputType("Amazon.WorkspacesInstances.Model.InstanceTypeInfo")]
    [AWSCmdlet("Calls the Amazon Workspaces Instances ListInstanceTypes API operation.", Operation = new[] {"ListInstanceTypes"}, SelectReturnType = typeof(Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse))]
    [AWSCmdletOutput("Amazon.WorkspacesInstances.Model.InstanceTypeInfo or Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse",
        "This cmdlet returns a collection of Amazon.WorkspacesInstances.Model.InstanceTypeInfo objects.",
        "The service call response (type Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWKSIInstanceTypeListCmdlet : AmazonWorkspacesInstancesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceConfigurationFilter_BillingMode
        /// <summary>
        /// <para>
        /// <para>Filters WorkSpace Instance types based on supported billing modes. Allows customers
        /// to search for instance types that support their preferred billing model, such as HOURLY
        /// or MONTHLY billing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.BillingMode")]
        public Amazon.WorkspacesInstances.BillingMode InstanceConfigurationFilter_BillingMode { get; set; }
        #endregion
        
        #region Parameter InstanceConfigurationFilter_PlatformType
        /// <summary>
        /// <para>
        /// <para>Filters WorkSpace Instance types by operating system platform. Allows customers to
        /// find instances that support their desired OS, such as Windows, Linux/UNIX, Ubuntu
        /// Pro, RHEL, or SUSE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.PlatformTypeEnum")]
        public Amazon.WorkspacesInstances.PlatformTypeEnum InstanceConfigurationFilter_PlatformType { get; set; }
        #endregion
        
        #region Parameter InstanceConfigurationFilter_Tenancy
        /// <summary>
        /// <para>
        /// <para>Filters WorkSpace Instance types by tenancy model. Allows customers to find instances
        /// that match their tenancy requirements, such as SHARED or DEDICATED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.InstanceConfigurationTenancyEnum")]
        public Amazon.WorkspacesInstances.InstanceConfigurationTenancyEnum InstanceConfigurationFilter_Tenancy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of instance types to return in a single API call. Enables pagination
        /// of instance type results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token for retrieving subsequent pages of instance type results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse).
        /// Specifying the name of a property of type Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceTypes";
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
                context.Select = CreateSelectDelegate<Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse, GetWKSIInstanceTypeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceConfigurationFilter_BillingMode = this.InstanceConfigurationFilter_BillingMode;
            context.InstanceConfigurationFilter_PlatformType = this.InstanceConfigurationFilter_PlatformType;
            context.InstanceConfigurationFilter_Tenancy = this.InstanceConfigurationFilter_Tenancy;
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
            var request = new Amazon.WorkspacesInstances.Model.ListInstanceTypesRequest();
            
            
             // populate InstanceConfigurationFilter
            var requestInstanceConfigurationFilterIsNull = true;
            request.InstanceConfigurationFilter = new Amazon.WorkspacesInstances.Model.InstanceConfigurationFilter();
            Amazon.WorkspacesInstances.BillingMode requestInstanceConfigurationFilter_instanceConfigurationFilter_BillingMode = null;
            if (cmdletContext.InstanceConfigurationFilter_BillingMode != null)
            {
                requestInstanceConfigurationFilter_instanceConfigurationFilter_BillingMode = cmdletContext.InstanceConfigurationFilter_BillingMode;
            }
            if (requestInstanceConfigurationFilter_instanceConfigurationFilter_BillingMode != null)
            {
                request.InstanceConfigurationFilter.BillingMode = requestInstanceConfigurationFilter_instanceConfigurationFilter_BillingMode;
                requestInstanceConfigurationFilterIsNull = false;
            }
            Amazon.WorkspacesInstances.PlatformTypeEnum requestInstanceConfigurationFilter_instanceConfigurationFilter_PlatformType = null;
            if (cmdletContext.InstanceConfigurationFilter_PlatformType != null)
            {
                requestInstanceConfigurationFilter_instanceConfigurationFilter_PlatformType = cmdletContext.InstanceConfigurationFilter_PlatformType;
            }
            if (requestInstanceConfigurationFilter_instanceConfigurationFilter_PlatformType != null)
            {
                request.InstanceConfigurationFilter.PlatformType = requestInstanceConfigurationFilter_instanceConfigurationFilter_PlatformType;
                requestInstanceConfigurationFilterIsNull = false;
            }
            Amazon.WorkspacesInstances.InstanceConfigurationTenancyEnum requestInstanceConfigurationFilter_instanceConfigurationFilter_Tenancy = null;
            if (cmdletContext.InstanceConfigurationFilter_Tenancy != null)
            {
                requestInstanceConfigurationFilter_instanceConfigurationFilter_Tenancy = cmdletContext.InstanceConfigurationFilter_Tenancy;
            }
            if (requestInstanceConfigurationFilter_instanceConfigurationFilter_Tenancy != null)
            {
                request.InstanceConfigurationFilter.Tenancy = requestInstanceConfigurationFilter_instanceConfigurationFilter_Tenancy;
                requestInstanceConfigurationFilterIsNull = false;
            }
             // determine if request.InstanceConfigurationFilter should be set to null
            if (requestInstanceConfigurationFilterIsNull)
            {
                request.InstanceConfigurationFilter = null;
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
        
        private Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse CallAWSServiceOperation(IAmazonWorkspacesInstances client, Amazon.WorkspacesInstances.Model.ListInstanceTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Workspaces Instances", "ListInstanceTypes");
            try
            {
                #if DESKTOP
                return client.ListInstanceTypes(request);
                #elif CORECLR
                return client.ListInstanceTypesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WorkspacesInstances.BillingMode InstanceConfigurationFilter_BillingMode { get; set; }
            public Amazon.WorkspacesInstances.PlatformTypeEnum InstanceConfigurationFilter_PlatformType { get; set; }
            public Amazon.WorkspacesInstances.InstanceConfigurationTenancyEnum InstanceConfigurationFilter_Tenancy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.WorkspacesInstances.Model.ListInstanceTypesResponse, GetWKSIInstanceTypeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceTypes;
        }
        
    }
}
