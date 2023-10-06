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
using Amazon.MarketplaceCatalog;
using Amazon.MarketplaceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.MCAT
{
    /// <summary>
    /// Allows you to request changes for your entities. Within a single <code>ChangeSet</code>,
    /// you can't start the same change type against the same entity multiple times. Additionally,
    /// when a <code>ChangeSet</code> is running, all the entities targeted by the different
    /// changes are locked until the change set has completed (either succeeded, cancelled,
    /// or failed). If you try to start a change set containing a change against an entity
    /// that is already locked, you will receive a <code>ResourceInUseException</code> error.
    /// 
    ///  
    /// <para>
    /// For example, you can't start the <code>ChangeSet</code> described in the <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/API_StartChangeSet.html#API_StartChangeSet_Examples">example</a>
    /// later in this topic because it contains two changes to run the same change type (<code>AddRevisions</code>)
    /// against the same entity (<code>entity-id@1</code>).
    /// </para><para>
    /// For more information about working with change sets, see <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/welcome.html#working-with-change-sets">
    /// Working with change sets</a>. For information about change types for single-AMI products,
    /// see <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/ami-products.html#working-with-single-AMI-products">Working
    /// with single-AMI products</a>. Also, for more information about change types available
    /// for container-based products, see <a href="https://docs.aws.amazon.com/marketplace-catalog/latest/api-reference/container-products.html#working-with-container-products">Working
    /// with container products</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "MCATChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceCatalog.Model.StartChangeSetResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Catalog Service StartChangeSet API operation.", Operation = new[] {"StartChangeSet"}, SelectReturnType = typeof(Amazon.MarketplaceCatalog.Model.StartChangeSetResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceCatalog.Model.StartChangeSetResponse",
        "This cmdlet returns an Amazon.MarketplaceCatalog.Model.StartChangeSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartMCATChangeSetCmdlet : AmazonMarketplaceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog related to the request. Fixed value: <code>AWSMarketplace</code></para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter ChangeSet
        /// <summary>
        /// <para>
        /// <para>Array of <code>change</code> object.</para>
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
        public Amazon.MarketplaceCatalog.Model.Change[] ChangeSet { get; set; }
        #endregion
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>Optional case sensitive string of up to 100 ASCII characters. The change set name
        /// can be used to filter the list of change sets. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter ChangeSetTag
        /// <summary>
        /// <para>
        /// <para>A list of objects specifying each key name and value for the <code>ChangeSetTags</code>
        /// property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChangeSetTags")]
        public Amazon.MarketplaceCatalog.Model.Tag[] ChangeSetTag { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique token to identify the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceCatalog.Model.StartChangeSetResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceCatalog.Model.StartChangeSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Catalog parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Catalog' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChangeSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MCATChangeSet (StartChangeSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceCatalog.Model.StartChangeSetResponse, StartMCATChangeSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Catalog;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChangeSet != null)
            {
                context.ChangeSet = new List<Amazon.MarketplaceCatalog.Model.Change>(this.ChangeSet);
            }
            #if MODULAR
            if (this.ChangeSet == null && ParameterWasBound(nameof(this.ChangeSet)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeSet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeSetName = this.ChangeSetName;
            if (this.ChangeSetTag != null)
            {
                context.ChangeSetTag = new List<Amazon.MarketplaceCatalog.Model.Tag>(this.ChangeSetTag);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            
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
            var request = new Amazon.MarketplaceCatalog.Model.StartChangeSetRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ChangeSet != null)
            {
                request.ChangeSet = cmdletContext.ChangeSet;
            }
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.ChangeSetTag != null)
            {
                request.ChangeSetTags = cmdletContext.ChangeSetTag;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
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
        
        private Amazon.MarketplaceCatalog.Model.StartChangeSetResponse CallAWSServiceOperation(IAmazonMarketplaceCatalog client, Amazon.MarketplaceCatalog.Model.StartChangeSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Catalog Service", "StartChangeSet");
            try
            {
                #if DESKTOP
                return client.StartChangeSet(request);
                #elif CORECLR
                return client.StartChangeSetAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public List<Amazon.MarketplaceCatalog.Model.Change> ChangeSet { get; set; }
            public System.String ChangeSetName { get; set; }
            public List<Amazon.MarketplaceCatalog.Model.Tag> ChangeSetTag { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Func<Amazon.MarketplaceCatalog.Model.StartChangeSetResponse, StartMCATChangeSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
