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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates an Amazon Redshift Query Editor (QEV2) IAM Identity Center application.
    /// </summary>
    [Cmdlet("New", "RSQev2IdcApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Qev2IdcApplication")]
    [AWSCmdlet("Calls the Amazon Redshift CreateQev2IdcApplication API operation.", Operation = new[] {"CreateQev2IdcApplication"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateQev2IdcApplicationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Qev2IdcApplication or Amazon.Redshift.Model.CreateQev2IdcApplicationResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Qev2IdcApplication object.",
        "The service call response (type Amazon.Redshift.Model.CreateQev2IdcApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRSQev2IdcApplicationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdcDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the Amazon Redshift Query Editor (QEV2) IAM Identity Center application.
        /// It appears in the console.</para>
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
        public System.String IdcDisplayName { get; set; }
        #endregion
        
        #region Parameter IdcInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM Identity Center instance used to create
        /// the Amazon Redshift Query Editor (QEV2) managed application.</para>
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
        public System.String IdcInstanceArn { get; set; }
        #endregion
        
        #region Parameter Qev2IdcApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Redshift Query Editor (QEV2) application in IAM Identity Center.</para>
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
        public System.String Qev2IdcApplicationName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the application. Tags are key-value pairs that you
        /// can use to organize and identify your resources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Qev2IdcApplication'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateQev2IdcApplicationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateQev2IdcApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Qev2IdcApplication";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Qev2IdcApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSQev2IdcApplication (CreateQev2IdcApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateQev2IdcApplicationResponse, NewRSQev2IdcApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdcDisplayName = this.IdcDisplayName;
            #if MODULAR
            if (this.IdcDisplayName == null && ParameterWasBound(nameof(this.IdcDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdcDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdcInstanceArn = this.IdcInstanceArn;
            #if MODULAR
            if (this.IdcInstanceArn == null && ParameterWasBound(nameof(this.IdcInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IdcInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Qev2IdcApplicationName = this.Qev2IdcApplicationName;
            #if MODULAR
            if (this.Qev2IdcApplicationName == null && ParameterWasBound(nameof(this.Qev2IdcApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter Qev2IdcApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Redshift.Model.CreateQev2IdcApplicationRequest();
            
            if (cmdletContext.IdcDisplayName != null)
            {
                request.IdcDisplayName = cmdletContext.IdcDisplayName;
            }
            if (cmdletContext.IdcInstanceArn != null)
            {
                request.IdcInstanceArn = cmdletContext.IdcInstanceArn;
            }
            if (cmdletContext.Qev2IdcApplicationName != null)
            {
                request.Qev2IdcApplicationName = cmdletContext.Qev2IdcApplicationName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Redshift.Model.CreateQev2IdcApplicationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateQev2IdcApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateQev2IdcApplication");
            try
            {
                return client.CreateQev2IdcApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IdcDisplayName { get; set; }
            public System.String IdcInstanceArn { get; set; }
            public System.String Qev2IdcApplicationName { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateQev2IdcApplicationResponse, NewRSQev2IdcApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Qev2IdcApplication;
        }
        
    }
}
