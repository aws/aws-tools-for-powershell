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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Initializes an Amazon Security Lake instance with the provided (or default) configuration.
    /// You can enable Security Lake in Amazon Web Services Regions with customized settings
    /// before enabling log collection in Regions. To specify particular Regions, configure
    /// these Regions using the <c>configurations</c> parameter. If you have already enabled
    /// Security Lake in a Region when you call this command, the command will update the
    /// Region if you provide new configuration parameters. If you have not already enabled
    /// Security Lake in the Region when you call this API, it will set up the data lake in
    /// the Region with the specified configurations.
    /// 
    ///  
    /// <para>
    /// When you enable Security Lake, it starts ingesting security data after the <c>CreateAwsLogSource</c>
    /// call and after you create subscribers using the <c>CreateSubscriber</c> API. This
    /// includes ingesting security data from sources, storing data, and making data accessible
    /// to subscribers. Security Lake also enables all the existing settings and resources
    /// that it stores or maintains for your Amazon Web Services account in the current Region,
    /// including security log and event data. For more information, see the <a href="https://docs.aws.amazon.com/security-lake/latest/userguide/what-is-security-lake.html">Amazon
    /// Security Lake User Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SLKDataLake", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.DataLakeResource")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateDataLake API operation.", Operation = new[] {"CreateDataLake"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateDataLakeResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.DataLakeResource or Amazon.SecurityLake.Model.CreateDataLakeResponse",
        "This cmdlet returns a collection of Amazon.SecurityLake.Model.DataLakeResource objects.",
        "The service call response (type Amazon.SecurityLake.Model.CreateDataLakeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSLKDataLakeCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>Specify the Region or Regions that will contribute data to the rollup region.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Configurations")]
        public Amazon.SecurityLake.Model.DataLakeConfiguration[] Configuration { get; set; }
        #endregion
        
        #region Parameter MetaStoreManagerRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) used to create and update the Glue table. This table
        /// contains partitions generated by the ingestion and normalization of Amazon Web Services
        /// log sources and custom sources.</para>
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
        public System.String MetaStoreManagerRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each tag to associate with the data lake configuration.
        /// For each tag, you must specify both a tag key and a tag value. A tag value cannot
        /// be null, but it can be an empty string.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SecurityLake.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataLakes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateDataLakeResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateDataLakeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataLakes";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetaStoreManagerRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKDataLake (CreateDataLake)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateDataLakeResponse, NewSLKDataLakeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Configuration != null)
            {
                context.Configuration = new List<Amazon.SecurityLake.Model.DataLakeConfiguration>(this.Configuration);
            }
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetaStoreManagerRoleArn = this.MetaStoreManagerRoleArn;
            #if MODULAR
            if (this.MetaStoreManagerRoleArn == null && ParameterWasBound(nameof(this.MetaStoreManagerRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaStoreManagerRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SecurityLake.Model.Tag>(this.Tag);
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
            var request = new Amazon.SecurityLake.Model.CreateDataLakeRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configurations = cmdletContext.Configuration;
            }
            if (cmdletContext.MetaStoreManagerRoleArn != null)
            {
                request.MetaStoreManagerRoleArn = cmdletContext.MetaStoreManagerRoleArn;
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
        
        private Amazon.SecurityLake.Model.CreateDataLakeResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateDataLakeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateDataLake");
            try
            {
                return client.CreateDataLakeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityLake.Model.DataLakeConfiguration> Configuration { get; set; }
            public System.String MetaStoreManagerRoleArn { get; set; }
            public List<Amazon.SecurityLake.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateDataLakeResponse, NewSLKDataLakeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataLakes;
        }
        
    }
}
