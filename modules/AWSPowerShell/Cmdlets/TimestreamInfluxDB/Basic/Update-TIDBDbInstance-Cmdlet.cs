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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Updates a Timestream for InfluxDB DB instance.
    /// </summary>
    [Cmdlet("Update", "TIDBDbInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB UpdateDbInstance API operation.", Operation = new[] {"UpdateDbInstance"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse",
        "This cmdlet returns an Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTIDBDbInstanceCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket to deliver logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfiguration_S3Configuration_BucketName")]
        public System.String S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter DbInstanceType
        /// <summary>
        /// <para>
        /// <para>The Timestream for InfluxDB DB instance type to run InfluxDB on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DbInstanceType")]
        public Amazon.TimestreamInfluxDB.DbInstanceType DbInstanceType { get; set; }
        #endregion
        
        #region Parameter DbParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The id of the DB parameter group to assign to your DB instance. DB parameter groups
        /// specify how the database is configured. For example, DB parameter groups can specify
        /// the limit for query concurrency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance will be deployed as a standalone instance or with
        /// a Multi-AZ standby for high availability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DeploymentType")]
        public Amazon.TimestreamInfluxDB.DeploymentType DeploymentType { get; set; }
        #endregion
        
        #region Parameter S3Configuration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether log delivery to the S3 bucket is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfiguration_S3Configuration_Enabled")]
        public System.Boolean? S3Configuration_Enabled { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The id of the DB instance.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TIDBDbInstance (UpdateDbInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse, UpdateTIDBDbInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DbInstanceType = this.DbInstanceType;
            context.DbParameterGroupIdentifier = this.DbParameterGroupIdentifier;
            context.DeploymentType = this.DeploymentType;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Configuration_BucketName = this.S3Configuration_BucketName;
            context.S3Configuration_Enabled = this.S3Configuration_Enabled;
            
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
            var request = new Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceRequest();
            
            if (cmdletContext.DbInstanceType != null)
            {
                request.DbInstanceType = cmdletContext.DbInstanceType;
            }
            if (cmdletContext.DbParameterGroupIdentifier != null)
            {
                request.DbParameterGroupIdentifier = cmdletContext.DbParameterGroupIdentifier;
            }
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate LogDeliveryConfiguration
            var requestLogDeliveryConfigurationIsNull = true;
            request.LogDeliveryConfiguration = new Amazon.TimestreamInfluxDB.Model.LogDeliveryConfiguration();
            Amazon.TimestreamInfluxDB.Model.S3Configuration requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = true;
            requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = new Amazon.TimestreamInfluxDB.Model.S3Configuration();
            System.String requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName = null;
            if (cmdletContext.S3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName = cmdletContext.S3Configuration_BucketName;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.BucketName = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName;
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = false;
            }
            System.Boolean? requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled = null;
            if (cmdletContext.S3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled = cmdletContext.S3Configuration_Enabled.Value;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.Enabled = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled.Value;
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration should be set to null
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = null;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration != null)
            {
                request.LogDeliveryConfiguration.S3Configuration = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration;
                requestLogDeliveryConfigurationIsNull = false;
            }
             // determine if request.LogDeliveryConfiguration should be set to null
            if (requestLogDeliveryConfigurationIsNull)
            {
                request.LogDeliveryConfiguration = null;
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
        
        private Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "UpdateDbInstance");
            try
            {
                #if DESKTOP
                return client.UpdateDbInstance(request);
                #elif CORECLR
                return client.UpdateDbInstanceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.TimestreamInfluxDB.DbInstanceType DbInstanceType { get; set; }
            public System.String DbParameterGroupIdentifier { get; set; }
            public Amazon.TimestreamInfluxDB.DeploymentType DeploymentType { get; set; }
            public System.String Identifier { get; set; }
            public System.String S3Configuration_BucketName { get; set; }
            public System.Boolean? S3Configuration_Enabled { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.UpdateDbInstanceResponse, UpdateTIDBDbInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
