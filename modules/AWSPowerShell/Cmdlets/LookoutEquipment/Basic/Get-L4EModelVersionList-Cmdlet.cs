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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Generates a list of all model versions for a given model, including the model version,
    /// model version ARN, and status. To list a subset of versions, use the <c>MaxModelVersion</c>
    /// and <c>MinModelVersion</c> fields.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "L4EModelVersionList")]
    [OutputType("Amazon.LookoutEquipment.Model.ModelVersionSummary")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment ListModelVersions API operation.", Operation = new[] {"ListModelVersions"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.ListModelVersionsResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.ModelVersionSummary or Amazon.LookoutEquipment.Model.ListModelVersionsResponse",
        "This cmdlet returns a collection of Amazon.LookoutEquipment.Model.ModelVersionSummary objects.",
        "The service call response (type Amazon.LookoutEquipment.Model.ListModelVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetL4EModelVersionListCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedAtEndTime
        /// <summary>
        /// <para>
        /// <para>Filter results to return all the model versions created before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAtEndTime { get; set; }
        #endregion
        
        #region Parameter CreatedAtStartTime
        /// <summary>
        /// <para>
        /// <para>Filter results to return all the model versions created after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAtStartTime { get; set; }
        #endregion
        
        #region Parameter MaxModelVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the highest version of the model to return in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MaxModelVersion { get; set; }
        #endregion
        
        #region Parameter MinModelVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the lowest version of the model to return in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MinModelVersion { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>Then name of the machine learning model for which the model versions are to be listed.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>Filter the results based on the way the model version was generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutEquipment.ModelVersionSourceType")]
        public Amazon.LookoutEquipment.ModelVersionSourceType SourceType { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter the results based on the current status of the model version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutEquipment.ModelVersionStatus")]
        public Amazon.LookoutEquipment.ModelVersionStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of machine learning model versions to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the total number of results exceeds the limit that the response can display, the
        /// response returns an opaque pagination token indicating where to continue the listing
        /// of machine learning model versions. Use this token in the <c>NextToken</c> field in
        /// the request to list the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelVersionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.ListModelVersionsResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.ListModelVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelVersionSummaries";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.ListModelVersionsResponse, GetL4EModelVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAtEndTime = this.CreatedAtEndTime;
            context.CreatedAtStartTime = this.CreatedAtStartTime;
            context.MaxModelVersion = this.MaxModelVersion;
            context.MaxResult = this.MaxResult;
            context.MinModelVersion = this.MinModelVersion;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SourceType = this.SourceType;
            context.Status = this.Status;
            
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
            var request = new Amazon.LookoutEquipment.Model.ListModelVersionsRequest();
            
            if (cmdletContext.CreatedAtEndTime != null)
            {
                request.CreatedAtEndTime = cmdletContext.CreatedAtEndTime.Value;
            }
            if (cmdletContext.CreatedAtStartTime != null)
            {
                request.CreatedAtStartTime = cmdletContext.CreatedAtStartTime.Value;
            }
            if (cmdletContext.MaxModelVersion != null)
            {
                request.MaxModelVersion = cmdletContext.MaxModelVersion.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MinModelVersion != null)
            {
                request.MinModelVersion = cmdletContext.MinModelVersion.Value;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.LookoutEquipment.Model.ListModelVersionsResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.ListModelVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "ListModelVersions");
            try
            {
                return client.ListModelVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedAtEndTime { get; set; }
            public System.DateTime? CreatedAtStartTime { get; set; }
            public System.Int64? MaxModelVersion { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.Int64? MinModelVersion { get; set; }
            public System.String ModelName { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LookoutEquipment.ModelVersionSourceType SourceType { get; set; }
            public Amazon.LookoutEquipment.ModelVersionStatus Status { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.ListModelVersionsResponse, GetL4EModelVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelVersionSummaries;
        }
        
    }
}
