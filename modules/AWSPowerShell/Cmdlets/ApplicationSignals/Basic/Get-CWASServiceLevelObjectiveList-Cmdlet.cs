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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Returns a list of SLOs created in this account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWASServiceLevelObjectiveList")]
    [OutputType("Amazon.ApplicationSignals.Model.ServiceLevelObjectiveSummary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals ListServiceLevelObjectives API operation.", Operation = new[] {"ListServiceLevelObjectives"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.ServiceLevelObjectiveSummary or Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse",
        "This cmdlet returns a collection of Amazon.ApplicationSignals.Model.ServiceLevelObjectiveSummary objects.",
        "The service call response (type Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWASServiceLevelObjectiveListCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DependencyConfig_DependencyKeyAttribute
        /// <summary>
        /// <para>
        /// <para>This is a string-to-string map. It can include the following fields.</para><ul><li><para><c>Type</c> designates the type of object this is.</para></li><li><para><c>ResourceType</c> specifies the type of the resource. This field is used only when
        /// the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Name</c> specifies the name of the object. This is used only if the value of the
        /// <c>Type</c> field is <c>Service</c>, <c>RemoteService</c>, or <c>AWS::Service</c>.</para></li><li><para><c>Identifier</c> identifies the resource objects of this resource. This is used
        /// only if the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Environment</c> specifies the location where this object is hosted, or what it
        /// belongs to.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DependencyConfig_DependencyKeyAttributes")]
        public System.Collections.Hashtable DependencyConfig_DependencyKeyAttribute { get; set; }
        #endregion
        
        #region Parameter DependencyConfig_DependencyOperationName
        /// <summary>
        /// <para>
        /// <para>The name of the called operation in the dependency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DependencyConfig_DependencyOperationName { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccount
        /// <summary>
        /// <para>
        /// Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesRequest.IncludeLinkedAccounts
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccounts")]
        public System.Boolean? IncludeLinkedAccount { get; set; }
        #endregion
        
        #region Parameter KeyAttribute
        /// <summary>
        /// <para>
        /// <para>You can use this optional field to specify which services you want to retrieve SLO
        /// information for.</para><para>This is a string-to-string map. It can include the following fields.</para><ul><li><para><c>Type</c> designates the type of object this is.</para></li><li><para><c>ResourceType</c> specifies the type of the resource. This field is used only when
        /// the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Name</c> specifies the name of the object. This is used only if the value of the
        /// <c>Type</c> field is <c>Service</c>, <c>RemoteService</c>, or <c>AWS::Service</c>.</para></li><li><para><c>Identifier</c> identifies the resource objects of this resource. This is used
        /// only if the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Environment</c> specifies the location where this object is hosted, or what it
        /// belongs to.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes")]
        public System.Collections.Hashtable KeyAttribute { get; set; }
        #endregion
        
        #region Parameter MetricSourceType
        /// <summary>
        /// <para>
        /// <para>Use this optional field to only include SLOs with the specified metric source types
        /// in the output. Supported types are:</para><ul><li><para>Service operation</para></li><li><para>Service dependency</para></li><li><para>CloudWatch metric</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSourceTypes")]
        public System.String[] MetricSourceType { get; set; }
        #endregion
        
        #region Parameter OperationName
        /// <summary>
        /// <para>
        /// <para>The name of the operation that this SLO is associated with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String OperationName { get; set; }
        #endregion
        
        #region Parameter SloOwnerAwsAccountId
        /// <summary>
        /// <para>
        /// <para>SLO's Amazon Web Services account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SloOwnerAwsAccountId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one operation. If you omit this parameter,
        /// the default of 50 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Include this value, if it was returned by the previous operation, to get the next
        /// set of service level objectives.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SloSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SloSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OperationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OperationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OperationName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse, GetCWASServiceLevelObjectiveListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OperationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DependencyConfig_DependencyKeyAttribute != null)
            {
                context.DependencyConfig_DependencyKeyAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DependencyConfig_DependencyKeyAttribute.Keys)
                {
                    context.DependencyConfig_DependencyKeyAttribute.Add((String)hashKey, (System.String)(this.DependencyConfig_DependencyKeyAttribute[hashKey]));
                }
            }
            context.DependencyConfig_DependencyOperationName = this.DependencyConfig_DependencyOperationName;
            context.IncludeLinkedAccount = this.IncludeLinkedAccount;
            if (this.KeyAttribute != null)
            {
                context.KeyAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KeyAttribute.Keys)
                {
                    context.KeyAttribute.Add((String)hashKey, (System.String)(this.KeyAttribute[hashKey]));
                }
            }
            context.MaxResult = this.MaxResult;
            if (this.MetricSourceType != null)
            {
                context.MetricSourceType = new List<System.String>(this.MetricSourceType);
            }
            context.NextToken = this.NextToken;
            context.OperationName = this.OperationName;
            context.SloOwnerAwsAccountId = this.SloOwnerAwsAccountId;
            
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
            var request = new Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesRequest();
            
            
             // populate DependencyConfig
            var requestDependencyConfigIsNull = true;
            request.DependencyConfig = new Amazon.ApplicationSignals.Model.DependencyConfig();
            Dictionary<System.String, System.String> requestDependencyConfig_dependencyConfig_DependencyKeyAttribute = null;
            if (cmdletContext.DependencyConfig_DependencyKeyAttribute != null)
            {
                requestDependencyConfig_dependencyConfig_DependencyKeyAttribute = cmdletContext.DependencyConfig_DependencyKeyAttribute;
            }
            if (requestDependencyConfig_dependencyConfig_DependencyKeyAttribute != null)
            {
                request.DependencyConfig.DependencyKeyAttributes = requestDependencyConfig_dependencyConfig_DependencyKeyAttribute;
                requestDependencyConfigIsNull = false;
            }
            System.String requestDependencyConfig_dependencyConfig_DependencyOperationName = null;
            if (cmdletContext.DependencyConfig_DependencyOperationName != null)
            {
                requestDependencyConfig_dependencyConfig_DependencyOperationName = cmdletContext.DependencyConfig_DependencyOperationName;
            }
            if (requestDependencyConfig_dependencyConfig_DependencyOperationName != null)
            {
                request.DependencyConfig.DependencyOperationName = requestDependencyConfig_dependencyConfig_DependencyOperationName;
                requestDependencyConfigIsNull = false;
            }
             // determine if request.DependencyConfig should be set to null
            if (requestDependencyConfigIsNull)
            {
                request.DependencyConfig = null;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.KeyAttribute != null)
            {
                request.KeyAttributes = cmdletContext.KeyAttribute;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MetricSourceType != null)
            {
                request.MetricSourceTypes = cmdletContext.MetricSourceType;
            }
            if (cmdletContext.OperationName != null)
            {
                request.OperationName = cmdletContext.OperationName;
            }
            if (cmdletContext.SloOwnerAwsAccountId != null)
            {
                request.SloOwnerAwsAccountId = cmdletContext.SloOwnerAwsAccountId;
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
        
        private Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "ListServiceLevelObjectives");
            try
            {
                #if DESKTOP
                return client.ListServiceLevelObjectives(request);
                #elif CORECLR
                return client.ListServiceLevelObjectivesAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> DependencyConfig_DependencyKeyAttribute { get; set; }
            public System.String DependencyConfig_DependencyOperationName { get; set; }
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public Dictionary<System.String, System.String> KeyAttribute { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> MetricSourceType { get; set; }
            public System.String NextToken { get; set; }
            public System.String OperationName { get; set; }
            public System.String SloOwnerAwsAccountId { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.ListServiceLevelObjectivesResponse, GetCWASServiceLevelObjectiveListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SloSummaries;
        }
        
    }
}
