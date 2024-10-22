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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    ///  Lists the entries (images) within a dataset. An entry is a JSON Line that contains
    /// the information for a single image, including the image location, assigned labels,
    /// and object location bounding boxes. For more information, see <a href="https://docs.aws.amazon.com/rekognition/latest/customlabels-dg/md-manifest-files.html">Creating
    /// a manifest file</a>.
    /// </para><para>
    /// JSON Lines in the response include information about non-terminal errors found in
    /// the dataset. Non terminal errors are reported in <c>errors</c> lists within each JSON
    /// Line. The same information is reported in the training and testing validation result
    /// manifests that Amazon Rekognition Custom Labels creates during model training. 
    /// </para><para>
    /// You can filter the response in variety of ways, such as choosing which labels to return
    /// and returning JSON Lines created after a specific date. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:ListDatasetEntries</c>
    /// action.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "REKDatasetEntryList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition ListDatasetEntries API operation.", Operation = new[] {"ListDatasetEntries"}, SelectReturnType = typeof(Amazon.Rekognition.Model.ListDatasetEntriesResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.ListDatasetEntriesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Rekognition.Model.ListDatasetEntriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetREKDatasetEntryListCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainsLabel
        /// <summary>
        /// <para>
        /// <para>Specifies a label filter for the response. The response includes an entry only if
        /// one or more of the labels in <c>ContainsLabels</c> exist in the entry. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainsLabels")]
        public System.String[] ContainsLabel { get; set; }
        #endregion
        
        #region Parameter DatasetArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) for the dataset that you want to use. </para>
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
        public System.String DatasetArn { get; set; }
        #endregion
        
        #region Parameter HasError
        /// <summary>
        /// <para>
        /// <para>Specifies an error filter for the response. Specify <c>True</c> to only include entries
        /// that have errors. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HasErrors")]
        public System.Boolean? HasError { get; set; }
        #endregion
        
        #region Parameter Labeled
        /// <summary>
        /// <para>
        /// <para> Specify <c>true</c> to get only the JSON Lines where the image is labeled. Specify
        /// <c>false</c> to get only the JSON Lines where the image isn't labeled. If you don't
        /// specify <c>Labeled</c>, <c>ListDatasetEntries</c> returns JSON Lines for labeled and
        /// unlabeled images. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Labeled { get; set; }
        #endregion
        
        #region Parameter SourceRefContain
        /// <summary>
        /// <para>
        /// <para>If specified, <c>ListDatasetEntries</c> only returns JSON Lines where the value of
        /// <c>SourceRefContains</c> is part of the <c>source-ref</c> field. The <c>source-ref</c>
        /// field contains the Amazon S3 location of the image. You can use <c>SouceRefContains</c>
        /// for tasks such as getting the JSON Line for a single image, or gettting JSON Lines
        /// for all images within a specific folder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceRefContains")]
        public System.String SourceRefContain { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per paginated call. The largest value you
        /// can specify is 100. If you specify a value greater than 100, a ValidationException
        /// error occurs. The default value is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more results to retrieve),
        /// Amazon Rekognition Custom Labels returns a pagination token in the response. You can
        /// use this pagination token to retrieve the next set of results. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.ListDatasetEntriesResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.ListDatasetEntriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetEntries";
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
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.ListDatasetEntriesResponse, GetREKDatasetEntryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContainsLabel != null)
            {
                context.ContainsLabel = new List<System.String>(this.ContainsLabel);
            }
            context.DatasetArn = this.DatasetArn;
            #if MODULAR
            if (this.DatasetArn == null && ParameterWasBound(nameof(this.DatasetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HasError = this.HasError;
            context.Labeled = this.Labeled;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SourceRefContain = this.SourceRefContain;
            
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
            var request = new Amazon.Rekognition.Model.ListDatasetEntriesRequest();
            
            if (cmdletContext.ContainsLabel != null)
            {
                request.ContainsLabels = cmdletContext.ContainsLabel;
            }
            if (cmdletContext.DatasetArn != null)
            {
                request.DatasetArn = cmdletContext.DatasetArn;
            }
            if (cmdletContext.HasError != null)
            {
                request.HasErrors = cmdletContext.HasError.Value;
            }
            if (cmdletContext.Labeled != null)
            {
                request.Labeled = cmdletContext.Labeled.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SourceRefContain != null)
            {
                request.SourceRefContains = cmdletContext.SourceRefContain;
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
        
        private Amazon.Rekognition.Model.ListDatasetEntriesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.ListDatasetEntriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "ListDatasetEntries");
            try
            {
                #if DESKTOP
                return client.ListDatasetEntries(request);
                #elif CORECLR
                return client.ListDatasetEntriesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContainsLabel { get; set; }
            public System.String DatasetArn { get; set; }
            public System.Boolean? HasError { get; set; }
            public System.Boolean? Labeled { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SourceRefContain { get; set; }
            public System.Func<Amazon.Rekognition.Model.ListDatasetEntriesResponse, GetREKDatasetEntryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetEntries;
        }
        
    }
}
