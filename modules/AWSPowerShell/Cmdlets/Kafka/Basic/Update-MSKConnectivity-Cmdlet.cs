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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Updates the cluster's connectivity configuration.
    /// </summary>
    [Cmdlet("Update", "MSKConnectivity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateConnectivityResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateConnectivity API operation.", Operation = new[] {"UpdateConnectivity"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateConnectivityResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateConnectivityResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateConnectivityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMSKConnectivityCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configuration.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MSK cluster to update. Cluster versions aren't simple numbers.
        /// You can describe an MSK cluster to find its version. When this update operation is
        /// successful, it generates a new cluster version.</para>
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
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter PublicAccess_Type
        /// <summary>
        /// <para>
        /// <para>The value DISABLED indicates that public access is turned off. SERVICE_PROVIDED_EIPS
        /// indicates that public access is turned on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectivityInfo_PublicAccess_Type")]
        public System.String PublicAccess_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateConnectivityResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateConnectivityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKConnectivity (UpdateConnectivity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateConnectivityResponse, UpdateMSKConnectivityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicAccess_Type = this.PublicAccess_Type;
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kafka.Model.UpdateConnectivityRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            
             // populate ConnectivityInfo
            var requestConnectivityInfoIsNull = true;
            request.ConnectivityInfo = new Amazon.Kafka.Model.ConnectivityInfo();
            Amazon.Kafka.Model.PublicAccess requestConnectivityInfo_connectivityInfo_PublicAccess = null;
            
             // populate PublicAccess
            var requestConnectivityInfo_connectivityInfo_PublicAccessIsNull = true;
            requestConnectivityInfo_connectivityInfo_PublicAccess = new Amazon.Kafka.Model.PublicAccess();
            System.String requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type = null;
            if (cmdletContext.PublicAccess_Type != null)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type = cmdletContext.PublicAccess_Type;
            }
            if (requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type != null)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess.Type = requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type;
                requestConnectivityInfo_connectivityInfo_PublicAccessIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_PublicAccess should be set to null
            if (requestConnectivityInfo_connectivityInfo_PublicAccessIsNull)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess = null;
            }
            if (requestConnectivityInfo_connectivityInfo_PublicAccess != null)
            {
                request.ConnectivityInfo.PublicAccess = requestConnectivityInfo_connectivityInfo_PublicAccess;
                requestConnectivityInfoIsNull = false;
            }
             // determine if request.ConnectivityInfo should be set to null
            if (requestConnectivityInfoIsNull)
            {
                request.ConnectivityInfo = null;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
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
        
        private Amazon.Kafka.Model.UpdateConnectivityResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateConnectivityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateConnectivity");
            try
            {
                #if DESKTOP
                return client.UpdateConnectivity(request);
                #elif CORECLR
                return client.UpdateConnectivityAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String PublicAccess_Type { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateConnectivityResponse, UpdateMSKConnectivityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
