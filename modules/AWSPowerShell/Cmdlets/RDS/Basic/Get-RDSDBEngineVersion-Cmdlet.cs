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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Describes the properties of specific versions of DB engines.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSDBEngineVersion")]
    [OutputType("Amazon.RDS.Model.DBEngineVersion")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeDBEngineVersions API operation.", Operation = new[] {"DescribeDBEngineVersions"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeDBEngineVersionsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBEngineVersion or Amazon.RDS.Model.DescribeDBEngineVersionsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.DBEngineVersion objects.",
        "The service call response (type Amazon.RDS.Model.DescribeDBEngineVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRDSDBEngineVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBParameterGroupFamily
        /// <summary>
        /// <para>
        /// <para>The name of a specific DB parameter group family to return details for.</para><para>Constraints:</para><ul><li><para>If supplied, must match an existing DB parameter group family.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupFamily { get; set; }
        #endregion
        
        #region Parameter DefaultOnly
        /// <summary>
        /// <para>
        /// <para>Specifies whether to return only the default version of the specified engine or the
        /// engine and major version combination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultOnly { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to return version details for.</para><para>Valid Values:</para><ul><li><para><code>aurora-mysql</code></para></li><li><para><code>aurora-postgresql</code></para></li><li><para><code>custom-oracle-ee</code></para></li><li><para><code>mariadb</code></para></li><li><para><code>mysql</code></para></li><li><para><code>oracle-ee</code></para></li><li><para><code>oracle-ee-cdb</code></para></li><li><para><code>oracle-se2</code></para></li><li><para><code>oracle-se2-cdb</code></para></li><li><para><code>postgres</code></para></li><li><para><code>sqlserver-ee</code></para></li><li><para><code>sqlserver-se</code></para></li><li><para><code>sqlserver-ex</code></para></li><li><para><code>sqlserver-web</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>A specific database engine version to return details for.</para><para>Example: <code>5.1.49</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies one or more DB engine versions to describe.</para><para>Supported filters:</para><ul><li><para><code>db-parameter-group-family</code> - Accepts parameter groups family names. The
        /// results list only includes information about the DB engine versions for these parameter
        /// group families.</para></li><li><para><code>engine</code> - Accepts engine names. The results list only includes information
        /// about the DB engine versions for these engines.</para></li><li><para><code>engine-mode</code> - Accepts DB engine modes. The results list only includes
        /// information about the DB engine versions for these engine modes. Valid DB engine modes
        /// are the following:</para><ul><li><para><code>global</code></para></li><li><para><code>multimaster</code></para></li><li><para><code>parallelquery</code></para></li><li><para><code>provisioned</code></para></li><li><para><code>serverless</code></para></li></ul></li><li><para><code>engine-version</code> - Accepts engine versions. The results list only includes
        /// information about the DB engine versions for these engine versions.</para></li><li><para><code>status</code> - Accepts engine version statuses. The results list only includes
        /// information about the DB engine versions for these statuses. Valid statuses are the
        /// following:</para><ul><li><para><code>available</code></para></li><li><para><code>deprecated</code></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeAll
        /// <summary>
        /// <para>
        /// <para>Specifies whether to also list the engine versions that aren't available. The default
        /// is to list only available engine versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeAll { get; set; }
        #endregion
        
        #region Parameter ListSupportedCharacterSet
        /// <summary>
        /// <para>
        /// <para>Specifies whether to list the supported character sets for each engine version.</para><para>If this parameter is enabled and the requested engine supports the <code>CharacterSetName</code>
        /// parameter for <code>CreateDBInstance</code>, the response includes a list of supported
        /// character sets for each engine version.</para><para>For RDS Custom, the default is not to list supported character sets. If you enable
        /// this parameter, RDS Custom returns no results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListSupportedCharacterSets")]
        public System.Boolean? ListSupportedCharacterSet { get; set; }
        #endregion
        
        #region Parameter ListSupportedTimezone
        /// <summary>
        /// <para>
        /// <para>Specifies whether to list the supported time zones for each engine version.</para><para>If this parameter is enabled and the requested engine supports the <code>TimeZone</code>
        /// parameter for <code>CreateDBInstance</code>, the response includes a list of supported
        /// time zones for each engine version.</para><para>For RDS Custom, the default is not to list supported time zones. If you enable this
        /// parameter, RDS Custom returns no results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListSupportedTimezones")]
        public System.Boolean? ListSupportedTimezone { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <code>MaxRecords</code>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more than the <code>MaxRecords</code>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBEngineVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeDBEngineVersionsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeDBEngineVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBEngineVersions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Engine parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Engine' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Engine' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeDBEngineVersionsResponse, GetRDSDBEngineVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Engine;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            context.DefaultOnly = this.DefaultOnly;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.IncludeAll = this.IncludeAll;
            context.ListSupportedCharacterSet = this.ListSupportedCharacterSet;
            context.ListSupportedTimezone = this.ListSupportedTimezone;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeDBEngineVersionsRequest();
            
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.DefaultOnly != null)
            {
                request.DefaultOnly = cmdletContext.DefaultOnly.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeAll != null)
            {
                request.IncludeAll = cmdletContext.IncludeAll.Value;
            }
            if (cmdletContext.ListSupportedCharacterSet != null)
            {
                request.ListSupportedCharacterSets = cmdletContext.ListSupportedCharacterSet.Value;
            }
            if (cmdletContext.ListSupportedTimezone != null)
            {
                request.ListSupportedTimezones = cmdletContext.ListSupportedTimezone.Value;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeDBEngineVersionsRequest();
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.DefaultOnly != null)
            {
                request.DefaultOnly = cmdletContext.DefaultOnly.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeAll != null)
            {
                request.IncludeAll = cmdletContext.IncludeAll.Value;
            }
            if (cmdletContext.ListSupportedCharacterSet != null)
            {
                request.ListSupportedCharacterSets = cmdletContext.ListSupportedCharacterSet.Value;
            }
            if (cmdletContext.ListSupportedTimezone != null)
            {
                request.ListSupportedTimezones = cmdletContext.ListSupportedTimezone.Value;
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
                    int _receivedThisCall = response.DBEngineVersions.Count;
                    
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
        
        private Amazon.RDS.Model.DescribeDBEngineVersionsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeDBEngineVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeDBEngineVersions");
            try
            {
                #if DESKTOP
                return client.DescribeDBEngineVersions(request);
                #elif CORECLR
                return client.DescribeDBEngineVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String DBParameterGroupFamily { get; set; }
            public System.Boolean? DefaultOnly { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.Boolean? IncludeAll { get; set; }
            public System.Boolean? ListSupportedCharacterSet { get; set; }
            public System.Boolean? ListSupportedTimezone { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeDBEngineVersionsResponse, GetRDSDBEngineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBEngineVersions;
        }
        
    }
}
