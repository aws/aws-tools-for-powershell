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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Update Connector.
    /// </summary>
    [Cmdlet("Update", "MGNConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateConnectorResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateConnector API operation.", Operation = new[] {"UpdateConnector"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateConnectorResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateConnectorResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateConnectorResponse object containing multiple properties."
    )]
    public partial class UpdateMGNConnectorCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SsmCommandConfig_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>Connector SSM command config CloudWatch log group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SsmCommandConfig_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter SsmCommandConfig_CloudWatchOutputEnabled
        /// <summary>
        /// <para>
        /// <para>Connector SSM command config CloudWatch output enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SsmCommandConfig_CloudWatchOutputEnabled { get; set; }
        #endregion
        
        #region Parameter ConnectorID
        /// <summary>
        /// <para>
        /// <para>Update Connector request connector ID.</para>
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
        public System.String ConnectorID { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Update Connector request name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SsmCommandConfig_OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>Connector SSM command config output S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SsmCommandConfig_OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter SsmCommandConfig_S3OutputEnabled
        /// <summary>
        /// <para>
        /// <para>Connector SSM command config S3 output enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SsmCommandConfig_S3OutputEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateConnectorResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNConnector (UpdateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateConnectorResponse, UpdateMGNConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorID = this.ConnectorID;
            #if MODULAR
            if (this.ConnectorID == null && ParameterWasBound(nameof(this.ConnectorID)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.SsmCommandConfig_CloudWatchLogGroupName = this.SsmCommandConfig_CloudWatchLogGroupName;
            context.SsmCommandConfig_CloudWatchOutputEnabled = this.SsmCommandConfig_CloudWatchOutputEnabled;
            context.SsmCommandConfig_OutputS3BucketName = this.SsmCommandConfig_OutputS3BucketName;
            context.SsmCommandConfig_S3OutputEnabled = this.SsmCommandConfig_S3OutputEnabled;
            
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
            var request = new Amazon.Mgn.Model.UpdateConnectorRequest();
            
            if (cmdletContext.ConnectorID != null)
            {
                request.ConnectorID = cmdletContext.ConnectorID;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SsmCommandConfig
            var requestSsmCommandConfigIsNull = true;
            request.SsmCommandConfig = new Amazon.Mgn.Model.ConnectorSsmCommandConfig();
            System.String requestSsmCommandConfig_ssmCommandConfig_CloudWatchLogGroupName = null;
            if (cmdletContext.SsmCommandConfig_CloudWatchLogGroupName != null)
            {
                requestSsmCommandConfig_ssmCommandConfig_CloudWatchLogGroupName = cmdletContext.SsmCommandConfig_CloudWatchLogGroupName;
            }
            if (requestSsmCommandConfig_ssmCommandConfig_CloudWatchLogGroupName != null)
            {
                request.SsmCommandConfig.CloudWatchLogGroupName = requestSsmCommandConfig_ssmCommandConfig_CloudWatchLogGroupName;
                requestSsmCommandConfigIsNull = false;
            }
            System.Boolean? requestSsmCommandConfig_ssmCommandConfig_CloudWatchOutputEnabled = null;
            if (cmdletContext.SsmCommandConfig_CloudWatchOutputEnabled != null)
            {
                requestSsmCommandConfig_ssmCommandConfig_CloudWatchOutputEnabled = cmdletContext.SsmCommandConfig_CloudWatchOutputEnabled.Value;
            }
            if (requestSsmCommandConfig_ssmCommandConfig_CloudWatchOutputEnabled != null)
            {
                request.SsmCommandConfig.CloudWatchOutputEnabled = requestSsmCommandConfig_ssmCommandConfig_CloudWatchOutputEnabled.Value;
                requestSsmCommandConfigIsNull = false;
            }
            System.String requestSsmCommandConfig_ssmCommandConfig_OutputS3BucketName = null;
            if (cmdletContext.SsmCommandConfig_OutputS3BucketName != null)
            {
                requestSsmCommandConfig_ssmCommandConfig_OutputS3BucketName = cmdletContext.SsmCommandConfig_OutputS3BucketName;
            }
            if (requestSsmCommandConfig_ssmCommandConfig_OutputS3BucketName != null)
            {
                request.SsmCommandConfig.OutputS3BucketName = requestSsmCommandConfig_ssmCommandConfig_OutputS3BucketName;
                requestSsmCommandConfigIsNull = false;
            }
            System.Boolean? requestSsmCommandConfig_ssmCommandConfig_S3OutputEnabled = null;
            if (cmdletContext.SsmCommandConfig_S3OutputEnabled != null)
            {
                requestSsmCommandConfig_ssmCommandConfig_S3OutputEnabled = cmdletContext.SsmCommandConfig_S3OutputEnabled.Value;
            }
            if (requestSsmCommandConfig_ssmCommandConfig_S3OutputEnabled != null)
            {
                request.SsmCommandConfig.S3OutputEnabled = requestSsmCommandConfig_ssmCommandConfig_S3OutputEnabled.Value;
                requestSsmCommandConfigIsNull = false;
            }
             // determine if request.SsmCommandConfig should be set to null
            if (requestSsmCommandConfigIsNull)
            {
                request.SsmCommandConfig = null;
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
        
        private Amazon.Mgn.Model.UpdateConnectorResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateConnector");
            try
            {
                #if DESKTOP
                return client.UpdateConnector(request);
                #elif CORECLR
                return client.UpdateConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectorID { get; set; }
            public System.String Name { get; set; }
            public System.String SsmCommandConfig_CloudWatchLogGroupName { get; set; }
            public System.Boolean? SsmCommandConfig_CloudWatchOutputEnabled { get; set; }
            public System.String SsmCommandConfig_OutputS3BucketName { get; set; }
            public System.Boolean? SsmCommandConfig_S3OutputEnabled { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateConnectorResponse, UpdateMGNConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
