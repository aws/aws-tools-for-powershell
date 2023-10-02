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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Retrieves a list of read sets.
    /// </summary>
    [Cmdlet("Get", "OMICSReadSetList")]
    [OutputType("Amazon.Omics.Model.ReadSetListItem")]
    [AWSCmdlet("Calls the Amazon Omics ListReadSets API operation.", Operation = new[] {"ListReadSets"}, SelectReturnType = typeof(Amazon.Omics.Model.ListReadSetsResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.ReadSetListItem or Amazon.Omics.Model.ListReadSetsResponse",
        "This cmdlet returns a collection of Amazon.Omics.Model.ReadSetListItem objects.",
        "The service call response (type Amazon.Omics.Model.ListReadSetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOMICSReadSetListCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>The filter's start date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The filter's end date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_CreationType
        /// <summary>
        /// <para>
        /// <para> The creation type of the read set. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.CreationType")]
        public Amazon.Omics.CreationType Filter_CreationType { get; set; }
        #endregion
        
        #region Parameter Filter_GeneratedFrom
        /// <summary>
        /// <para>
        /// <para> Where the source originated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_GeneratedFrom { get; set; }
        #endregion
        
        #region Parameter Filter_Name
        /// <summary>
        /// <para>
        /// <para>A name to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Name { get; set; }
        #endregion
        
        #region Parameter Filter_ReferenceArn
        /// <summary>
        /// <para>
        /// <para>A genome reference ARN to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_ReferenceArn { get; set; }
        #endregion
        
        #region Parameter Filter_SampleId
        /// <summary>
        /// <para>
        /// <para> The read set source's sample ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_SampleId { get; set; }
        #endregion
        
        #region Parameter SequenceStoreId
        /// <summary>
        /// <para>
        /// <para>The jobs' sequence store ID.</para>
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
        public System.String SequenceStoreId { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>A status to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.ReadSetStatus")]
        public Amazon.Omics.ReadSetStatus Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_SubjectId
        /// <summary>
        /// <para>
        /// <para> The read set source's subject ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_SubjectId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of read sets to return in one page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token from a previous request to retrieve the next page of
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReadSets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.ListReadSetsResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.ListReadSetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReadSets";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SequenceStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SequenceStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SequenceStoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.ListReadSetsResponse, GetOMICSReadSetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SequenceStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_CreationType = this.Filter_CreationType;
            context.Filter_GeneratedFrom = this.Filter_GeneratedFrom;
            context.Filter_Name = this.Filter_Name;
            context.Filter_ReferenceArn = this.Filter_ReferenceArn;
            context.Filter_SampleId = this.Filter_SampleId;
            context.Filter_Status = this.Filter_Status;
            context.Filter_SubjectId = this.Filter_SubjectId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SequenceStoreId = this.SequenceStoreId;
            #if MODULAR
            if (this.SequenceStoreId == null && ParameterWasBound(nameof(this.SequenceStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter SequenceStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Omics.Model.ListReadSetsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Omics.Model.ReadSetFilter();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Omics.CreationType requestFilter_filter_CreationType = null;
            if (cmdletContext.Filter_CreationType != null)
            {
                requestFilter_filter_CreationType = cmdletContext.Filter_CreationType;
            }
            if (requestFilter_filter_CreationType != null)
            {
                request.Filter.CreationType = requestFilter_filter_CreationType;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_GeneratedFrom = null;
            if (cmdletContext.Filter_GeneratedFrom != null)
            {
                requestFilter_filter_GeneratedFrom = cmdletContext.Filter_GeneratedFrom;
            }
            if (requestFilter_filter_GeneratedFrom != null)
            {
                request.Filter.GeneratedFrom = requestFilter_filter_GeneratedFrom;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_Name = null;
            if (cmdletContext.Filter_Name != null)
            {
                requestFilter_filter_Name = cmdletContext.Filter_Name;
            }
            if (requestFilter_filter_Name != null)
            {
                request.Filter.Name = requestFilter_filter_Name;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_ReferenceArn = null;
            if (cmdletContext.Filter_ReferenceArn != null)
            {
                requestFilter_filter_ReferenceArn = cmdletContext.Filter_ReferenceArn;
            }
            if (requestFilter_filter_ReferenceArn != null)
            {
                request.Filter.ReferenceArn = requestFilter_filter_ReferenceArn;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_SampleId = null;
            if (cmdletContext.Filter_SampleId != null)
            {
                requestFilter_filter_SampleId = cmdletContext.Filter_SampleId;
            }
            if (requestFilter_filter_SampleId != null)
            {
                request.Filter.SampleId = requestFilter_filter_SampleId;
                requestFilterIsNull = false;
            }
            Amazon.Omics.ReadSetStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_SubjectId = null;
            if (cmdletContext.Filter_SubjectId != null)
            {
                requestFilter_filter_SubjectId = cmdletContext.Filter_SubjectId;
            }
            if (requestFilter_filter_SubjectId != null)
            {
                request.Filter.SubjectId = requestFilter_filter_SubjectId;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SequenceStoreId != null)
            {
                request.SequenceStoreId = cmdletContext.SequenceStoreId;
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
        
        private Amazon.Omics.Model.ListReadSetsResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.ListReadSetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "ListReadSets");
            try
            {
                #if DESKTOP
                return client.ListReadSets(request);
                #elif CORECLR
                return client.ListReadSetsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public Amazon.Omics.CreationType Filter_CreationType { get; set; }
            public System.String Filter_GeneratedFrom { get; set; }
            public System.String Filter_Name { get; set; }
            public System.String Filter_ReferenceArn { get; set; }
            public System.String Filter_SampleId { get; set; }
            public Amazon.Omics.ReadSetStatus Filter_Status { get; set; }
            public System.String Filter_SubjectId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SequenceStoreId { get; set; }
            public System.Func<Amazon.Omics.Model.ListReadSetsResponse, GetOMICSReadSetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReadSets;
        }
        
    }
}
