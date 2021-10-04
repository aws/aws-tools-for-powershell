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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Lists all Source Servers or multiple Source Servers filtered by ID.
    /// </summary>
    [Cmdlet("Get", "EDRSSourceServer")]
    [OutputType("Amazon.Drs.Model.SourceServer")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeSourceServers API operation.", Operation = new[] {"DescribeSourceServers"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeSourceServersResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.SourceServer or Amazon.Drs.Model.DescribeSourceServersResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.SourceServer objects.",
        "The service call response (type Amazon.Drs.Model.DescribeSourceServersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEDRSSourceServerCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_HardwareId
        /// <summary>
        /// <para>
        /// <para>An ID that describes the hardware of the Source Server. This is either an EC2 instance
        /// id, a VMware uuid or a mac address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Filters_HardwareId { get; set; }
        #endregion
        
        #region Parameter Filters_SourceServerIDs
        /// <summary>
        /// <para>
        /// <para>An array of Source Servers IDs that should be returned. An empty array means all Source
        /// Servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_SourceServerIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of Source Servers to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Source Server to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeSourceServersResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeSourceServersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Filters_HardwareId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Filters_HardwareId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Filters_HardwareId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeSourceServersResponse, GetEDRSSourceServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Filters_HardwareId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filters_HardwareId = this.Filters_HardwareId;
            if (this.Filters_SourceServerIDs != null)
            {
                context.Filters_SourceServerIDs = new List<System.String>(this.Filters_SourceServerIDs);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Drs.Model.DescribeSourceServersRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Drs.Model.DescribeSourceServersRequestFilters();
            System.String requestFilters_filters_HardwareId = null;
            if (cmdletContext.Filters_HardwareId != null)
            {
                requestFilters_filters_HardwareId = cmdletContext.Filters_HardwareId;
            }
            if (requestFilters_filters_HardwareId != null)
            {
                request.Filters.HardwareId = requestFilters_filters_HardwareId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SourceServerIDs = null;
            if (cmdletContext.Filters_SourceServerIDs != null)
            {
                requestFilters_filters_SourceServerIDs = cmdletContext.Filters_SourceServerIDs;
            }
            if (requestFilters_filters_SourceServerIDs != null)
            {
                request.Filters.SourceServerIDs = requestFilters_filters_SourceServerIDs;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Drs.Model.DescribeSourceServersResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeSourceServersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeSourceServers");
            try
            {
                #if DESKTOP
                return client.DescribeSourceServers(request);
                #elif CORECLR
                return client.DescribeSourceServersAsync(request).GetAwaiter().GetResult();
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
            public System.String Filters_HardwareId { get; set; }
            public List<System.String> Filters_SourceServerIDs { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeSourceServersResponse, GetEDRSSourceServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
