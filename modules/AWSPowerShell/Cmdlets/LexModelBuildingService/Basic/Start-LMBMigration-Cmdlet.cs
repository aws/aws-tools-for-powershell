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
using System.Threading;
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Starts migrating a bot from Amazon Lex V1 to Amazon Lex V2. Migrate your bot when
    /// you want to take advantage of the new features of Amazon Lex V2.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/lex/latest/dg/migrate.html">Migrating
    /// a bot</a> in the <i>Amazon Lex developer guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LMBMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.StartMigrationResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service StartMigration API operation.", Operation = new[] {"StartMigration"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.StartMigrationResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.StartMigrationResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.StartMigrationResponse object containing multiple properties."
    )]
    public partial class StartLMBMigrationCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MigrationStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy used to conduct the migration.</para><ul><li><para><c>CREATE_NEW</c> - Creates a new Amazon Lex V2 bot and migrates the Amazon Lex V1
        /// bot to the new bot.</para></li><li><para><c>UPDATE_EXISTING</c> - Overwrites the existing Amazon Lex V2 bot metadata and the
        /// locale being migrated. It doesn't change any other locales in the Amazon Lex V2 bot.
        /// If the locale doesn't exist, a new locale is created in the Amazon Lex V2 bot.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.MigrationStrategy")]
        public Amazon.LexModelBuildingService.MigrationStrategy MigrationStrategy { get; set; }
        #endregion
        
        #region Parameter V1BotName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Lex V1 bot that you are migrating to Amazon Lex V2.</para>
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
        public System.String V1BotName { get; set; }
        #endregion
        
        #region Parameter V1BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot to migrate to Amazon Lex V2. You can migrate the <c>$LATEST</c>
        /// version as well as any numbered version.</para>
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
        public System.String V1BotVersion { get; set; }
        #endregion
        
        #region Parameter V2BotName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Lex V2 bot that you are migrating the Amazon Lex V1 bot to.
        /// </para><ul><li><para>If the Amazon Lex V2 bot doesn't exist, you must use the <c>CREATE_NEW</c> migration
        /// strategy.</para></li><li><para>If the Amazon Lex V2 bot exists, you must use the <c>UPDATE_EXISTING</c> migration
        /// strategy to change the contents of the Amazon Lex V2 bot.</para></li></ul>
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
        public System.String V2BotName { get; set; }
        #endregion
        
        #region Parameter V2BotRole
        /// <summary>
        /// <para>
        /// <para>The IAM role that Amazon Lex uses to run the Amazon Lex V2 bot.</para>
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
        public System.String V2BotRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.StartMigrationResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.StartMigrationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBMigration (StartMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.StartMigrationResponse, StartLMBMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MigrationStrategy = this.MigrationStrategy;
            #if MODULAR
            if (this.MigrationStrategy == null && ParameterWasBound(nameof(this.MigrationStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.V1BotName = this.V1BotName;
            #if MODULAR
            if (this.V1BotName == null && ParameterWasBound(nameof(this.V1BotName)))
            {
                WriteWarning("You are passing $null as a value for parameter V1BotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.V1BotVersion = this.V1BotVersion;
            #if MODULAR
            if (this.V1BotVersion == null && ParameterWasBound(nameof(this.V1BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter V1BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.V2BotName = this.V2BotName;
            #if MODULAR
            if (this.V2BotName == null && ParameterWasBound(nameof(this.V2BotName)))
            {
                WriteWarning("You are passing $null as a value for parameter V2BotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.V2BotRole = this.V2BotRole;
            #if MODULAR
            if (this.V2BotRole == null && ParameterWasBound(nameof(this.V2BotRole)))
            {
                WriteWarning("You are passing $null as a value for parameter V2BotRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelBuildingService.Model.StartMigrationRequest();
            
            if (cmdletContext.MigrationStrategy != null)
            {
                request.MigrationStrategy = cmdletContext.MigrationStrategy;
            }
            if (cmdletContext.V1BotName != null)
            {
                request.V1BotName = cmdletContext.V1BotName;
            }
            if (cmdletContext.V1BotVersion != null)
            {
                request.V1BotVersion = cmdletContext.V1BotVersion;
            }
            if (cmdletContext.V2BotName != null)
            {
                request.V2BotName = cmdletContext.V2BotName;
            }
            if (cmdletContext.V2BotRole != null)
            {
                request.V2BotRole = cmdletContext.V2BotRole;
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
        
        private Amazon.LexModelBuildingService.Model.StartMigrationResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.StartMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "StartMigration");
            try
            {
                return client.StartMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LexModelBuildingService.MigrationStrategy MigrationStrategy { get; set; }
            public System.String V1BotName { get; set; }
            public System.String V1BotVersion { get; set; }
            public System.String V2BotName { get; set; }
            public System.String V2BotRole { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.StartMigrationResponse, StartLMBMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
