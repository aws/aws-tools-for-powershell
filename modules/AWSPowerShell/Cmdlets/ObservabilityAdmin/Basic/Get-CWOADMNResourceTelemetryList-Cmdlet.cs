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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Returns a list of telemetry configurations for AWS resources supported by telemetry
    /// config. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/telemetry-config-cloudwatch.html">Auditing
    /// CloudWatch telemetry configurations</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOADMNResourceTelemetryList")]
    [OutputType("Amazon.ObservabilityAdmin.Model.TelemetryConfiguration")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service ListResourceTelemetry API operation.", Operation = new[] {"ListResourceTelemetry"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.TelemetryConfiguration or Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse",
        "This cmdlet returns a collection of Amazon.ObservabilityAdmin.Model.TelemetryConfiguration objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOADMNResourceTelemetryListCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceIdentifierPrefix
        /// <summary>
        /// <para>
        /// <para> A string used to filter resources which have a <c>ResourceIdentifier</c> starting
        /// with the <c>ResourceIdentifierPrefix</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceIdentifierPrefix { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para> A key-value pair to filter resources based on tags associated with the resource.
        /// For more information about tags, see <a href="https://docs.aws.amazon.com/whitepapers/latest/tagging-best-practices/what-are-tags.html">What
        /// are tags?</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public System.Collections.Hashtable ResourceTag { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para> A list of resource types used to filter resources supported by telemetry config.
        /// If this parameter is provided, the resources will be returned in the same order used
        /// in the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter TelemetryConfigurationState
        /// <summary>
        /// <para>
        /// <para> A key-value pair to filter resources based on the telemetry type and the state of
        /// the telemetry configuration. The key is the telemetry type and the value is the state.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable TelemetryConfigurationState { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> A number field used to limit the number of results within the returned list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token for the next set of items to return. A previous call generates this token.
        /// </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TelemetryConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TelemetryConfigurations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifierPrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifierPrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifierPrefix' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse, GetCWOADMNResourceTelemetryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifierPrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceIdentifierPrefix = this.ResourceIdentifierPrefix;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResourceTag.Keys)
                {
                    context.ResourceTag.Add((String)hashKey, (System.String)(this.ResourceTag[hashKey]));
                }
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            if (this.TelemetryConfigurationState != null)
            {
                context.TelemetryConfigurationState = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TelemetryConfigurationState.Keys)
                {
                    context.TelemetryConfigurationState.Add((String)hashKey, (System.String)(this.TelemetryConfigurationState[hashKey]));
                }
            }
            
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
            var request = new Amazon.ObservabilityAdmin.Model.ListResourceTelemetryRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceIdentifierPrefix != null)
            {
                request.ResourceIdentifierPrefix = cmdletContext.ResourceIdentifierPrefix;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
            }
            if (cmdletContext.TelemetryConfigurationState != null)
            {
                request.TelemetryConfigurationState = cmdletContext.TelemetryConfigurationState;
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
        
        private Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.ListResourceTelemetryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "ListResourceTelemetry");
            try
            {
                #if DESKTOP
                return client.ListResourceTelemetry(request);
                #elif CORECLR
                return client.ListResourceTelemetryAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceIdentifierPrefix { get; set; }
            public Dictionary<System.String, System.String> ResourceTag { get; set; }
            public List<System.String> ResourceType { get; set; }
            public Dictionary<System.String, System.String> TelemetryConfigurationState { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.ListResourceTelemetryResponse, GetCWOADMNResourceTelemetryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TelemetryConfigurations;
        }
        
    }
}
