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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Lists available reserved DB instance offerings.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSReservedDBInstancesOfferingList")]
    [OutputType("Amazon.RDS.Model.ReservedDBInstancesOffering")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeReservedDBInstancesOfferings API operation.", Operation = new[] {"DescribeReservedDBInstancesOfferings"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse), LegacyAlias="Get-RDSReservedDBInstancesOfferings")]
    [AWSCmdletOutput("Amazon.RDS.Model.ReservedDBInstancesOffering or Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.ReservedDBInstancesOffering objects.",
        "The service call response (type Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSReservedDBInstancesOfferingListCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The DB instance class filter value. Specify this parameter to show only the available
        /// offerings matching the specified DB instance class.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>Duration filter value, specified in years or seconds. Specify this parameter to show
        /// only reservations for this duration.</para><para>Valid Values: <c>1 | 3 | 31536000 | 94608000</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Duration { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter isn't currently supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies whether to show only those reservations that support Multi-AZ.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The offering type filter value. Specify this parameter to show only the available
        /// offerings matching the specified offering type.</para><para>Valid Values: <c>"Partial Upfront" | "All Upfront" | "No Upfront" </c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OfferingType { get; set; }
        #endregion
        
        #region Parameter ProductDescription
        /// <summary>
        /// <para>
        /// <para>Product description filter value. Specify this parameter to show only the available
        /// offerings that contain the specified product description.</para><note><para>The results show offerings that partially match the filter value.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProductDescription { get; set; }
        #endregion
        
        #region Parameter ReservedDBInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>The offering identifier filter value. Specify this parameter to show only the available
        /// offering that matches the specified reservation identifier.</para><para>Example: <c>438012d3-4052-4cc7-b2e3-8d3372e0e706</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedDBInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <c>MaxRecords</c>.</para>
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
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more than the <c>MaxRecords</c>
        /// value is available, a pagination token called a marker is included in the response
        /// so you can retrieve the remaining results.</para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedDBInstancesOfferings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedDBInstancesOfferings";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse, GetRDSReservedDBInstancesOfferingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBInstanceClass = this.DBInstanceClass;
            context.Duration = this.Duration;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MultiAZ = this.MultiAZ;
            context.OfferingType = this.OfferingType;
            context.ProductDescription = this.ProductDescription;
            context.ReservedDBInstancesOfferingId = this.ReservedDBInstancesOfferingId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsRequest();
            
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedDBInstancesOfferingId != null)
            {
                request.ReservedDBInstancesOfferingId = cmdletContext.ReservedDBInstancesOfferingId;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsRequest();
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedDBInstancesOfferingId != null)
            {
                request.ReservedDBInstancesOfferingId = cmdletContext.ReservedDBInstancesOfferingId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord.HasValue)
            {
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.ReservedDBInstancesOfferings?.Count ?? 0;
                    
                    _nextToken = response.Marker;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeReservedDBInstancesOfferings");
            try
            {
                return client.DescribeReservedDBInstancesOfferingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBInstanceClass { get; set; }
            public System.String Duration { get; set; }
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String OfferingType { get; set; }
            public System.String ProductDescription { get; set; }
            public System.String ReservedDBInstancesOfferingId { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeReservedDBInstancesOfferingsResponse, GetRDSReservedDBInstancesOfferingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedDBInstancesOfferings;
        }
        
    }
}
