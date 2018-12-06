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
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace Amazon.PowerShell.Cmdlets.SD
{
    /// <summary>
    /// Discovers registered instances for a specified namespace and service.
    /// </summary>
    [Cmdlet("Find", "SDInstance")]
    [OutputType("Amazon.ServiceDiscovery.Model.HttpInstanceSummary")]
    [AWSCmdlet("Calls the Amazon Route 53 Auto Naming DiscoverInstances API operation.", Operation = new[] {"DiscoverInstances"})]
    [AWSCmdletOutput("Amazon.ServiceDiscovery.Model.HttpInstanceSummary",
        "This cmdlet returns a collection of HttpInstanceSummary objects.",
        "The service call response (type Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindSDInstanceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        #region Parameter HealthStatus
        /// <summary>
        /// <para>
        /// <para>The health status of the instances that you want to discover.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceDiscovery.HealthStatusFilter")]
        public Amazon.ServiceDiscovery.HealthStatusFilter HealthStatus { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace that you specified when you registered the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter QueryParameter
        /// <summary>
        /// <para>
        /// <para>A string map that contains attributes with values that you can use to filter instances
        /// by any custom attribute that you specified when you registered the instance. Only
        /// instances that match all the specified key/value pairs will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("QueryParameters")]
        public System.Collections.Hashtable QueryParameter { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service that you specified when you registered the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances that you want Cloud Map to return in the response
        /// to a <code>DiscoverInstances</code> request. If you don't specify a value for <code>MaxResults</code>,
        /// Cloud Map returns up to 100 instances.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
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
            
            context.HealthStatus = this.HealthStatus;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NamespaceName = this.NamespaceName;
            if (this.QueryParameter != null)
            {
                context.QueryParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryParameter.Keys)
                {
                    context.QueryParameters.Add((String)hashKey, (String)(this.QueryParameter[hashKey]));
                }
            }
            context.ServiceName = this.ServiceName;
            
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
            var request = new Amazon.ServiceDiscovery.Model.DiscoverInstancesRequest();
            
            if (cmdletContext.HealthStatus != null)
            {
                request.HealthStatus = cmdletContext.HealthStatus;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResults.Value);
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
            }
            if (cmdletContext.QueryParameters != null)
            {
                request.QueryParameters = cmdletContext.QueryParameters;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Instances;
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
        
        private Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.DiscoverInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Auto Naming", "DiscoverInstances");
            try
            {
                #if DESKTOP
                return client.DiscoverInstances(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DiscoverInstancesAsync(request);
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
            public Amazon.ServiceDiscovery.HealthStatusFilter HealthStatus { get; set; }
            public int? MaxResults { get; set; }
            public System.String NamespaceName { get; set; }
            public Dictionary<System.String, System.String> QueryParameters { get; set; }
            public System.String ServiceName { get; set; }
        }
        
    }
}
