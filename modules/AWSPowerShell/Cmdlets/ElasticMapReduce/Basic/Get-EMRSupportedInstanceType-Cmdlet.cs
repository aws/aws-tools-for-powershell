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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// A list of the instance types that Amazon EMR supports. You can filter the list by
    /// Amazon Web Services Region and Amazon EMR release.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EMRSupportedInstanceType")]
    [OutputType("Amazon.ElasticMapReduce.Model.SupportedInstanceType")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ListSupportedInstanceTypes API operation.", Operation = new[] {"ListSupportedInstanceTypes"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.SupportedInstanceType or Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse",
        "This cmdlet returns a collection of Amazon.ElasticMapReduce.Model.SupportedInstanceType objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMRSupportedInstanceTypeCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The Amazon EMR release label determines the <a href="https://docs.aws.amazon.com/emr/latest/ReleaseGuide/emr-release-app-versions-6.x.html">versions
        /// of open-source application packages</a> that Amazon EMR has installed on the cluster.
        /// Release labels are in the format <c>emr-x.x.x</c>, where x.x.x is an Amazon EMR release
        /// number such as <c>emr-6.10.0</c>. For more information about Amazon EMR releases and
        /// their included application versions and features, see the <i><a href="https://docs.aws.amazon.com/emr/latest/ReleaseGuide/emr-release-components.html">Amazon
        /// EMR Release Guide</a></i>.</para>
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
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token that marks the next set of results to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SupportedInstanceTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SupportedInstanceTypes";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReleaseLabel parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReleaseLabel' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReleaseLabel' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse, GetEMRSupportedInstanceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReleaseLabel;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Marker = this.Marker;
            context.ReleaseLabel = this.ReleaseLabel;
            #if MODULAR
            if (this.ReleaseLabel == null && ParameterWasBound(nameof(this.ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesRequest();
            
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ListSupportedInstanceTypes");
            try
            {
                #if DESKTOP
                return client.ListSupportedInstanceTypes(request);
                #elif CORECLR
                return client.ListSupportedInstanceTypesAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.String ReleaseLabel { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ListSupportedInstanceTypesResponse, GetEMRSupportedInstanceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SupportedInstanceTypes;
        }
        
    }
}
