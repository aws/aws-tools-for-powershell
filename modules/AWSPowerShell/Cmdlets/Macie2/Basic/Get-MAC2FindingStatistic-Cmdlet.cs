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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves (queries) aggregated statistical data about findings.
    /// </summary>
    [Cmdlet("Get", "MAC2FindingStatistic")]
    [OutputType("Amazon.Macie2.Model.GroupCount")]
    [AWSCmdlet("Calls the Amazon Macie 2 GetFindingStatistics API operation.", Operation = new[] {"GetFindingStatistics"}, SelectReturnType = typeof(Amazon.Macie2.Model.GetFindingStatisticsResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.GroupCount or Amazon.Macie2.Model.GetFindingStatisticsResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.GroupCount objects.",
        "The service call response (type Amazon.Macie2.Model.GetFindingStatisticsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMAC2FindingStatisticCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter SortCriteria_AttributeName
        /// <summary>
        /// <para>
        /// <para>The grouping to sort the results by. Valid values are: count, sort the results by
        /// the number of findings in each group of results; and, groupKey, sort the results by
        /// the name of each group of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.FindingStatisticsSortAttributeName")]
        public Amazon.Macie2.FindingStatisticsSortAttributeName SortCriteria_AttributeName { get; set; }
        #endregion
        
        #region Parameter FindingCriteria_Criterion
        /// <summary>
        /// <para>
        /// <para>A condition that specifies the property, operator, and value to use to filter the
        /// results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable FindingCriteria_Criterion { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The finding property to use to group the query results. Valid values are:</para><ul><li><para>classificationDetails.jobId - The unique identifier for the classification job that
        /// produced the finding.</para></li><li><para>resourcesAffected.s3Bucket.name - The name of the S3 bucket that the finding applies
        /// to.</para></li><li><para>severity.description - The severity level of the finding, such as High or Medium.</para></li><li><para>type - The type of finding, such as Policy:IAMUser/S3BucketPublic and SensitiveData:S3Object/Personal.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Macie2.GroupBy")]
        public Amazon.Macie2.GroupBy GroupBy { get; set; }
        #endregion
        
        #region Parameter SortCriteria_OrderBy
        /// <summary>
        /// <para>
        /// <para>The sort order to apply to the results, based on the value for the property specified
        /// by the attributeName property. Valid values are: ASC, sort the results in ascending
        /// order; and, DESC, sort the results in descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.OrderBy")]
        public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in each page of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Size { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CountsByGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.GetFindingStatisticsResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.GetFindingStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CountsByGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupBy parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupBy' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupBy' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.GetFindingStatisticsResponse, GetMAC2FindingStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupBy;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FindingCriteria_Criterion != null)
            {
                context.FindingCriteria_Criterion = new Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties>(StringComparer.Ordinal);
                foreach (var hashKey in this.FindingCriteria_Criterion.Keys)
                {
                    context.FindingCriteria_Criterion.Add((String)hashKey, (CriterionAdditionalProperties)(this.FindingCriteria_Criterion[hashKey]));
                }
            }
            context.GroupBy = this.GroupBy;
            #if MODULAR
            if (this.GroupBy == null && ParameterWasBound(nameof(this.GroupBy)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupBy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Size = this.Size;
            context.SortCriteria_AttributeName = this.SortCriteria_AttributeName;
            context.SortCriteria_OrderBy = this.SortCriteria_OrderBy;
            
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
            var request = new Amazon.Macie2.Model.GetFindingStatisticsRequest();
            
            
             // populate FindingCriteria
            var requestFindingCriteriaIsNull = true;
            request.FindingCriteria = new Amazon.Macie2.Model.FindingCriteria();
            Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties> requestFindingCriteria_findingCriteria_Criterion = null;
            if (cmdletContext.FindingCriteria_Criterion != null)
            {
                requestFindingCriteria_findingCriteria_Criterion = cmdletContext.FindingCriteria_Criterion;
            }
            if (requestFindingCriteria_findingCriteria_Criterion != null)
            {
                request.FindingCriteria.Criterion = requestFindingCriteria_findingCriteria_Criterion;
                requestFindingCriteriaIsNull = false;
            }
             // determine if request.FindingCriteria should be set to null
            if (requestFindingCriteriaIsNull)
            {
                request.FindingCriteria = null;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size.Value;
            }
            
             // populate SortCriteria
            var requestSortCriteriaIsNull = true;
            request.SortCriteria = new Amazon.Macie2.Model.FindingStatisticsSortCriteria();
            Amazon.Macie2.FindingStatisticsSortAttributeName requestSortCriteria_sortCriteria_AttributeName = null;
            if (cmdletContext.SortCriteria_AttributeName != null)
            {
                requestSortCriteria_sortCriteria_AttributeName = cmdletContext.SortCriteria_AttributeName;
            }
            if (requestSortCriteria_sortCriteria_AttributeName != null)
            {
                request.SortCriteria.AttributeName = requestSortCriteria_sortCriteria_AttributeName;
                requestSortCriteriaIsNull = false;
            }
            Amazon.Macie2.OrderBy requestSortCriteria_sortCriteria_OrderBy = null;
            if (cmdletContext.SortCriteria_OrderBy != null)
            {
                requestSortCriteria_sortCriteria_OrderBy = cmdletContext.SortCriteria_OrderBy;
            }
            if (requestSortCriteria_sortCriteria_OrderBy != null)
            {
                request.SortCriteria.OrderBy = requestSortCriteria_sortCriteria_OrderBy;
                requestSortCriteriaIsNull = false;
            }
             // determine if request.SortCriteria should be set to null
            if (requestSortCriteriaIsNull)
            {
                request.SortCriteria = null;
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
        
        private Amazon.Macie2.Model.GetFindingStatisticsResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.GetFindingStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "GetFindingStatistics");
            try
            {
                #if DESKTOP
                return client.GetFindingStatistics(request);
                #elif CORECLR
                return client.GetFindingStatisticsAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Macie2.Model.CriterionAdditionalProperties> FindingCriteria_Criterion { get; set; }
            public Amazon.Macie2.GroupBy GroupBy { get; set; }
            public System.Int32? Size { get; set; }
            public Amazon.Macie2.FindingStatisticsSortAttributeName SortCriteria_AttributeName { get; set; }
            public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
            public System.Func<Amazon.Macie2.Model.GetFindingStatisticsResponse, GetMAC2FindingStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CountsByGroup;
        }
        
    }
}
