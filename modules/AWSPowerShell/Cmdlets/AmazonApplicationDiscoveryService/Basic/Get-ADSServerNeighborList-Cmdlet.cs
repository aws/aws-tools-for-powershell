/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Retrieves a list of servers that are one network hop away from a specified server.
    /// </summary>
    [Cmdlet("Get", "ADSServerNeighborList")]
    [OutputType("Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse")]
    [AWSCmdlet("Calls the Application Discovery Service ListServerNeighbors API operation.", Operation = new[] {"ListServerNeighbors"})]
    [AWSCmdletOutput("Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse",
        "This cmdlet returns a Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetADSServerNeighborListCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationId
        /// <summary>
        /// <para>
        /// <para>Configuration ID of the server for which neighbors are being listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationId { get; set; }
        #endregion
        
        #region Parameter NeighborConfigurationId
        /// <summary>
        /// <para>
        /// <para>List of configuration IDs to test for one-hop-away.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NeighborConfigurationIds")]
        public System.String[] NeighborConfigurationId { get; set; }
        #endregion
        
        #region Parameter PortInformationNeeded
        /// <summary>
        /// <para>
        /// <para>Flag to indicate if port and protocol information is needed as part of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PortInformationNeeded { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results to return in a single page of output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token to retrieve the next set of results. For example, if you previously specified
        /// 100 IDs for <code>ListServerNeighborsRequest$neighborConfigurationIds</code> but set
        /// <code>ListServerNeighborsRequest$maxResults</code> to 10, you received a set of 10
        /// results along with a token. Use that token in this query to get the next set of 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationId = this.ConfigurationId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (this.NeighborConfigurationId != null)
            {
                context.NeighborConfigurationIds = new List<System.String>(this.NeighborConfigurationId);
            }
            context.NextToken = this.NextToken;
            if (ParameterWasBound("PortInformationNeeded"))
                context.PortInformationNeeded = this.PortInformationNeeded;
            
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
            var request = new Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsRequest();
            
            if (cmdletContext.ConfigurationId != null)
            {
                request.ConfigurationId = cmdletContext.ConfigurationId;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NeighborConfigurationIds != null)
            {
                request.NeighborConfigurationIds = cmdletContext.NeighborConfigurationIds;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PortInformationNeeded != null)
            {
                request.PortInformationNeeded = cmdletContext.PortInformationNeeded.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.ListServerNeighborsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Discovery Service", "ListServerNeighbors");
            try
            {
                #if DESKTOP
                return client.ListServerNeighbors(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListServerNeighborsAsync(request);
                return task.Result;
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
            public System.String ConfigurationId { get; set; }
            public System.Int32? MaxResults { get; set; }
            public List<System.String> NeighborConfigurationIds { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? PortInformationNeeded { get; set; }
        }
        
    }
}
