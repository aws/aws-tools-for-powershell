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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Creates a view that users can query by using the <a>Search</a> operation. Results
    /// from queries that you make using this view include only resources that match the view's
    /// <c>Filters</c>. For more information about Amazon Web Services Resource Explorer views,
    /// see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/manage-views.html">Managing
    /// views</a> in the <i>Amazon Web Services Resource Explorer User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Only the principals with an IAM identity-based policy that grants <c>Allow</c> to
    /// the <c>Search</c> action on a <c>Resource</c> with the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
    /// resource name (ARN)</a> of this view can <a>Search</a> using views you create with
    /// this operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AREXView", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResourceExplorer2.Model.View")]
    [AWSCmdlet("Calls the AWS Resource Explorer CreateView API operation.", Operation = new[] {"CreateView"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.CreateViewResponse))]
    [AWSCmdletOutput("Amazon.ResourceExplorer2.Model.View or Amazon.ResourceExplorer2.Model.CreateViewResponse",
        "This cmdlet returns an Amazon.ResourceExplorer2.Model.View object.",
        "The service call response (type Amazon.ResourceExplorer2.Model.CreateViewResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAREXViewCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_FilterString
        /// <summary>
        /// <para>
        /// <para>The string that contains the search keywords, prefixes, and operators to control the
        /// results that can be returned by a <a>Search</a> operation. For more details, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/APIReference/about-query-syntax.html">Search
        /// query syntax</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_FilterString { get; set; }
        #endregion
        
        #region Parameter IncludedProperty
        /// <summary>
        /// <para>
        /// <para>Specifies optional fields that you want included in search results from this view.
        /// It is a list of objects that each describe a field to include.</para><para>The default is an empty list, with no optional fields included in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludedProperties")]
        public Amazon.ResourceExplorer2.Model.IncludedProperty[] IncludedProperty { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The root ARN of the account, an organizational unit (OU), or an organization ARN.
        /// If left empty, the default is account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scope { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tag key and value pairs that are attached to the view.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ViewName
        /// <summary>
        /// <para>
        /// <para>The name of the new view. This name appears in the list of views in Resource Explorer.</para><para>The name must be no more than 64 characters long, and can include letters, digits,
        /// and the dash (-) character. The name must be unique within its Amazon Web Services
        /// Region.</para>
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
        public System.String ViewName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>This value helps ensure idempotency. Resource Explorer uses this value to prevent
        /// the accidental creation of duplicate versions. We recommend that you generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type value</a>
        /// to ensure the uniqueness of your views.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'View'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.CreateViewResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.CreateViewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "View";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ViewName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AREXView (CreateView)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.CreateViewResponse, NewAREXViewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Filters_FilterString = this.Filters_FilterString;
            if (this.IncludedProperty != null)
            {
                context.IncludedProperty = new List<Amazon.ResourceExplorer2.Model.IncludedProperty>(this.IncludedProperty);
            }
            context.Scope = this.Scope;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.ViewName = this.ViewName;
            #if MODULAR
            if (this.ViewName == null && ParameterWasBound(nameof(this.ViewName)))
            {
                WriteWarning("You are passing $null as a value for parameter ViewName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.ResourceExplorer2.Model.CreateViewRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ResourceExplorer2.Model.SearchFilter();
            System.String requestFilters_filters_FilterString = null;
            if (cmdletContext.Filters_FilterString != null)
            {
                requestFilters_filters_FilterString = cmdletContext.Filters_FilterString;
            }
            if (requestFilters_filters_FilterString != null)
            {
                request.Filters.FilterString = requestFilters_filters_FilterString;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.IncludedProperty != null)
            {
                request.IncludedProperties = cmdletContext.IncludedProperty;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ViewName != null)
            {
                request.ViewName = cmdletContext.ViewName;
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
        
        private Amazon.ResourceExplorer2.Model.CreateViewResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.CreateViewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "CreateView");
            try
            {
                #if DESKTOP
                return client.CreateView(request);
                #elif CORECLR
                return client.CreateViewAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Filters_FilterString { get; set; }
            public List<Amazon.ResourceExplorer2.Model.IncludedProperty> IncludedProperty { get; set; }
            public System.String Scope { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String ViewName { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.CreateViewResponse, NewAREXViewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.View;
        }
        
    }
}
