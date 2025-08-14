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
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;

namespace Amazon.PowerShell.Cmdlets.SD
{
    /// <summary>
    /// Discovers registered instances for a specified namespace and service. You can use
    /// <c>DiscoverInstances</c> to discover instances for any type of namespace. <c>DiscoverInstances</c>
    /// returns a randomized list of instances allowing customers to distribute traffic evenly
    /// across instances. For public and private DNS namespaces, you can also use DNS queries
    /// to discover instances.
    /// </summary>
    [Cmdlet("Find", "SDInstance")]
    [OutputType("Amazon.ServiceDiscovery.Model.HttpInstanceSummary")]
    [AWSCmdlet("Calls the AWS Cloud Map DiscoverInstances API operation.", Operation = new[] {"DiscoverInstances"}, SelectReturnType = typeof(Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse))]
    [AWSCmdletOutput("Amazon.ServiceDiscovery.Model.HttpInstanceSummary or Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse",
        "This cmdlet returns a collection of Amazon.ServiceDiscovery.Model.HttpInstanceSummary objects.",
        "The service call response (type Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindSDInstanceCmdlet : AmazonServiceDiscoveryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HealthStatus
        /// <summary>
        /// <para>
        /// <para>The health status of the instances that you want to discover. This parameter is ignored
        /// for services that don't have a health check configured, and all instances are returned.</para><dl><dt>HEALTHY</dt><dd><para>Returns healthy instances.</para></dd><dt>UNHEALTHY</dt><dd><para>Returns unhealthy instances.</para></dd><dt>ALL</dt><dd><para>Returns all instances.</para></dd><dt>HEALTHY_OR_ELSE_ALL</dt><dd><para>Returns healthy instances, unless none are reporting a healthy state. In that case,
        /// return all instances. This is also called failing open.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceDiscovery.HealthStatusFilter")]
        public Amazon.ServiceDiscovery.HealthStatusFilter HealthStatus { get; set; }
        #endregion
        
        #region Parameter NamespaceName
        /// <summary>
        /// <para>
        /// <para>The <c>HttpName</c> name of the namespace. The <c>HttpName</c> is found in the <c>HttpProperties</c>
        /// member of the <c>Properties</c> member of the namespace. In most cases, <c>Name</c>
        /// and <c>HttpName</c> match. However, if you reuse <c>Name</c> for namespace creation,
        /// a generated hash is added to <c>HttpName</c> to distinguish the two.</para>
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
        public System.String NamespaceName { get; set; }
        #endregion
        
        #region Parameter OptionalParameter
        /// <summary>
        /// <para>
        /// <para>Opportunistic filters to scope the results based on custom attributes. If there are
        /// instances that match both the filters specified in both the <c>QueryParameters</c>
        /// parameter and this parameter, all of these instances are returned. Otherwise, the
        /// filters are ignored, and only instances that match the filters that are specified
        /// in the <c>QueryParameters</c> parameter are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptionalParameters")]
        public System.Collections.Hashtable OptionalParameter { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the namespace associated with
        /// the instance, as specified in the namespace <c>ResourceOwner</c> field. For instances
        /// associated with namespaces that are shared with your account, you must specify an
        /// <c>OwnerAccount</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter QueryParameter
        /// <summary>
        /// <para>
        /// <para>Filters to scope the results based on custom attributes for the instance (for example,
        /// <c>{version=v1, az=1a}</c>). Only instances that match all the specified key-value
        /// pairs are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryParameters")]
        public System.Collections.Hashtable QueryParameter { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service that you specified when you registered the instance.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances that you want Cloud Map to return in the response
        /// to a <c>DiscoverInstances</c> request. If you don't specify a value for <c>MaxResults</c>,
        /// Cloud Map returns up to 100 instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse).
        /// Specifying the name of a property of type Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse, FindSDInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HealthStatus = this.HealthStatus;
            context.MaxResult = this.MaxResult;
            context.NamespaceName = this.NamespaceName;
            #if MODULAR
            if (this.NamespaceName == null && ParameterWasBound(nameof(this.NamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OptionalParameter != null)
            {
                context.OptionalParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OptionalParameter.Keys)
                {
                    context.OptionalParameter.Add((String)hashKey, (System.String)(this.OptionalParameter[hashKey]));
                }
            }
            context.OwnerAccount = this.OwnerAccount;
            if (this.QueryParameter != null)
            {
                context.QueryParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.QueryParameter.Keys)
                {
                    context.QueryParameter.Add((String)hashKey, (System.String)(this.QueryParameter[hashKey]));
                }
            }
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceDiscovery.Model.DiscoverInstancesRequest();
            
            if (cmdletContext.HealthStatus != null)
            {
                request.HealthStatus = cmdletContext.HealthStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NamespaceName != null)
            {
                request.NamespaceName = cmdletContext.NamespaceName;
            }
            if (cmdletContext.OptionalParameter != null)
            {
                request.OptionalParameters = cmdletContext.OptionalParameter;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
            }
            if (cmdletContext.QueryParameter != null)
            {
                request.QueryParameters = cmdletContext.QueryParameter;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
        
        private Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse CallAWSServiceOperation(IAmazonServiceDiscovery client, Amazon.ServiceDiscovery.Model.DiscoverInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Map", "DiscoverInstances");
            try
            {
                #if DESKTOP
                return client.DiscoverInstances(request);
                #elif CORECLR
                return client.DiscoverInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NamespaceName { get; set; }
            public Dictionary<System.String, System.String> OptionalParameter { get; set; }
            public System.String OwnerAccount { get; set; }
            public Dictionary<System.String, System.String> QueryParameter { get; set; }
            public System.String ServiceName { get; set; }
            public System.Func<Amazon.ServiceDiscovery.Model.DiscoverInstancesResponse, FindSDInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
