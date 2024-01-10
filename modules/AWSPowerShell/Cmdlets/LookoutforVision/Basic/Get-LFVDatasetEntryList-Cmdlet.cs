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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Lists the JSON Lines within a dataset. An Amazon Lookout for Vision JSON Line contains
    /// the anomaly information for a single image, including the image location and the assigned
    /// label.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <c>lookoutvision:ListDatasetEntries</c>
    /// operation.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LFVDatasetEntryList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision ListDatasetEntries API operation.", Operation = new[] {"ListDatasetEntries"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.ListDatasetEntriesResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutforVision.Model.ListDatasetEntriesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.LookoutforVision.Model.ListDatasetEntriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLFVDatasetEntryListCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AfterCreationDate
        /// <summary>
        /// <para>
        /// <para>Only includes entries after the specified date in the response. For example, <c>2020-06-23T00:00:00</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AfterCreationDate { get; set; }
        #endregion
        
        #region Parameter AnomalyClass
        /// <summary>
        /// <para>
        /// <para>Specify <c>normal</c> to include only normal images. Specify <c>anomaly</c> to only
        /// include anomalous entries. If you don't specify a value, Amazon Lookout for Vision
        /// returns normal and anomalous images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalyClass { get; set; }
        #endregion
        
        #region Parameter BeforeCreationDate
        /// <summary>
        /// <para>
        /// <para>Only includes entries before the specified date in the response. For example, <c>2020-06-23T00:00:00</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? BeforeCreationDate { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para>The type of the dataset that you want to list. Specify <c>train</c> to list the training
        /// dataset. Specify <c>test</c> to list the test dataset. If you have a single dataset
        /// project, specify <c>train</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetType { get; set; }
        #endregion
        
        #region Parameter Labeled
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to include labeled entries, otherwise specify <c>false</c>. If
        /// you don't specify a value, Lookout for Vision returns all entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Labeled { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project that contains the dataset that you want to list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter SourceRefContain
        /// <summary>
        /// <para>
        /// <para>Perform a "contains" search on the values of the <c>source-ref</c> key within the
        /// dataset. For example a value of "IMG_17" returns all JSON Lines where the <c>source-ref</c>
        /// key value matches <i>*IMG_17*</i>.</para>
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
        /// error occurs. The default value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was incomplete (because there is more data to retrieve),
        /// Amazon Lookout for Vision returns a pagination token in the response. You can use
        /// this pagination token to retrieve the next set of dataset entries.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.ListDatasetEntriesResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.ListDatasetEntriesResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.ListDatasetEntriesResponse, GetLFVDatasetEntryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AfterCreationDate = this.AfterCreationDate;
            context.AnomalyClass = this.AnomalyClass;
            context.BeforeCreationDate = this.BeforeCreationDate;
            context.DatasetType = this.DatasetType;
            #if MODULAR
            if (this.DatasetType == null && ParameterWasBound(nameof(this.DatasetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Labeled = this.Labeled;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.LookoutforVision.Model.ListDatasetEntriesRequest();
            
            if (cmdletContext.AfterCreationDate != null)
            {
                request.AfterCreationDate = cmdletContext.AfterCreationDate.Value;
            }
            if (cmdletContext.AnomalyClass != null)
            {
                request.AnomalyClass = cmdletContext.AnomalyClass;
            }
            if (cmdletContext.BeforeCreationDate != null)
            {
                request.BeforeCreationDate = cmdletContext.BeforeCreationDate.Value;
            }
            if (cmdletContext.DatasetType != null)
            {
                request.DatasetType = cmdletContext.DatasetType;
            }
            if (cmdletContext.Labeled != null)
            {
                request.Labeled = cmdletContext.Labeled.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.ListDatasetEntriesResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.ListDatasetEntriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "ListDatasetEntries");
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
            public System.DateTime? AfterCreationDate { get; set; }
            public System.String AnomalyClass { get; set; }
            public System.DateTime? BeforeCreationDate { get; set; }
            public System.String DatasetType { get; set; }
            public System.Boolean? Labeled { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProjectName { get; set; }
            public System.String SourceRefContain { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.ListDatasetEntriesResponse, GetLFVDatasetEntryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetEntries;
        }
        
    }
}
