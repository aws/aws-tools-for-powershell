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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Enables Lake query federation on the specified event data store. Federating an event
    /// data store lets you view the metadata associated with the event data store in the
    /// Glue <a href="https://docs.aws.amazon.com/glue/latest/dg/components-overview.html#data-catalog-intro">Data
    /// Catalog</a> and run SQL queries against your event data using Amazon Athena. The table
    /// metadata stored in the Glue Data Catalog lets the Athena query engine know how to
    /// find, read, and process the data that you want to query.
    /// 
    ///  
    /// <para>
    /// When you enable Lake query federation, CloudTrail creates a managed database named
    /// <c>aws:cloudtrail</c> (if the database doesn't already exist) and a managed federated
    /// table in the Glue Data Catalog. The event data store ID is used for the table name.
    /// CloudTrail registers the role ARN and event data store in <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/query-federation-lake-formation.html">Lake
    /// Formation</a>, the service responsible for allowing fine-grained access control of
    /// the federated resources in the Glue Data Catalog.
    /// </para><para>
    /// For more information about Lake query federation, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/query-federation.html">Federate
    /// an event data store</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "CTFederation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.EnableFederationResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail EnableFederation API operation.", Operation = new[] {"EnableFederation"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.EnableFederationResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.EnableFederationResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.EnableFederationResponse object containing multiple properties."
    )]
    public partial class EnableCTFederationCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventDataStore
        /// <summary>
        /// <para>
        /// <para>The ARN (or ID suffix of the ARN) of the event data store for which you want to enable
        /// Lake query federation.</para>
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
        public System.String EventDataStore { get; set; }
        #endregion
        
        #region Parameter FederationRoleArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the federation role to use for the event data store. Amazon Web Services
        /// services like Lake Formation use this federation role to access data for the federated
        /// event data store. The federation role must exist in your account and provide the <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/query-federation.html#query-federation-permissions-role">required
        /// minimum permissions</a>. </para>
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
        public System.String FederationRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.EnableFederationResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.EnableFederationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FederationRoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FederationRoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FederationRoleArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FederationRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-CTFederation (EnableFederation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.EnableFederationResponse, EnableCTFederationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FederationRoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventDataStore = this.EventDataStore;
            #if MODULAR
            if (this.EventDataStore == null && ParameterWasBound(nameof(this.EventDataStore)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDataStore which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FederationRoleArn = this.FederationRoleArn;
            #if MODULAR
            if (this.FederationRoleArn == null && ParameterWasBound(nameof(this.FederationRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FederationRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudTrail.Model.EnableFederationRequest();
            
            if (cmdletContext.EventDataStore != null)
            {
                request.EventDataStore = cmdletContext.EventDataStore;
            }
            if (cmdletContext.FederationRoleArn != null)
            {
                request.FederationRoleArn = cmdletContext.FederationRoleArn;
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
        
        private Amazon.CloudTrail.Model.EnableFederationResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.EnableFederationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "EnableFederation");
            try
            {
                #if DESKTOP
                return client.EnableFederation(request);
                #elif CORECLR
                return client.EnableFederationAsync(request).GetAwaiter().GetResult();
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
            public System.String EventDataStore { get; set; }
            public System.String FederationRoleArn { get; set; }
            public System.Func<Amazon.CloudTrail.Model.EnableFederationResponse, EnableCTFederationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
