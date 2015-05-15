/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Lists available reserved DB instance offerings.
    /// </summary>
    [Cmdlet("Get", "RDSReservedDBInstancesOfferings")]
    [OutputType("Amazon.RDS.Model.ReservedDBInstancesOffering")]
    [AWSCmdlet("Invokes the DescribeReservedDBInstancesOfferings operation against Amazon Relational Database Service.", Operation = new[] {"DescribeReservedDBInstancesOfferings"})]
    [AWSCmdletOutput("Amazon.RDS.Model.ReservedDBInstancesOffering",
        "This cmdlet returns a collection of ReservedDBInstancesOffering objects.",
        "The service call response (type DescribeReservedDBInstancesOfferingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetRDSReservedDBInstancesOfferingsCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The DB instance class filter value. Specify this parameter to show only the available
        /// offerings matching the specified DB instance class. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DBInstanceClass { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Duration filter value, specified in years or seconds. Specify this parameter to show
        /// only reservations for this duration. </para><para>Valid Values: <code>1 | 3 | 31536000 | 94608000</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Duration { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The Multi-AZ filter value. Specify this parameter to show only the available offerings
        /// matching the specified Multi-AZ parameter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean MultiAZ { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The offering type filter value. Specify this parameter to show only the available
        /// offerings matching the specified offering type. </para><para>Valid Values: <code>"Light Utilization" | "Medium Utilization" | "Heavy Utilization"
        /// </code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String OfferingType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Product description filter value. Specify this parameter to show only the available
        /// offerings matching the specified product description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ProductDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The offering identifier filter value. Specify this parameter to show only the available
        /// offering that matches the specified reservation identifier. </para><para>Example: <code>438012d3-4052-4cc7-b2e3-8d3372e0e706</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ReservedDBInstancesOfferingId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <code>MaxRecords</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more than the <code>MaxRecords</code>
        /// value is available, a pagination token called a marker is included in the response
        /// so that the following results can be retrieved. </para><para>Default: 100</para><para>Constraints: minimum 20, maximum 100</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBInstanceClass = this.DBInstanceClass;
            context.Duration = this.Duration;
            if (this.Filter != null)
            {
                context.Filters = new List<Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.OfferingType = this.OfferingType;
            context.ProductDescription = this.ProductDescription;
            context.ReservedDBInstancesOfferingId = this.ReservedDBInstancesOfferingId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new DescribeReservedDBInstancesOfferingsRequest();
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
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
            String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeReservedDBInstancesOfferings(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ReservedDBInstancesOfferings;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ReservedDBInstancesOfferings.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String DBInstanceClass { get; set; }
            public String Duration { get; set; }
            public List<Filter> Filters { get; set; }
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public Boolean? MultiAZ { get; set; }
            public String OfferingType { get; set; }
            public String ProductDescription { get; set; }
            public String ReservedDBInstancesOfferingId { get; set; }
        }
        
    }
}
